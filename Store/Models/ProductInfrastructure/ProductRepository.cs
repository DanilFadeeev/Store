using Dapper;
using Store.Data;
using Store.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class ProductRepository : IProductRepository
    {
        string ConnectionString { get; }
        public ICategoryRepository Repo { get; }

        public ProductRepository(IConnectionStringProvider connection,ICategoryRepository repo)
        {
            ConnectionString = connection.ConnectionString;
            Repo = repo;
        }
        public async Task<List<T>> GetProducts<T>(string category) where T : Product
        {
            SqlConnection conn = new(ConnectionString);
            List<T> result = new();
            foreach (var c in await Repo.GetNotAbstractChildren(category))
                result.AddRange((await conn.QueryAsync<T>($"select * from products where Category='{c}'")).ToList());
            result.AddRange((await conn.QueryAsync<T>($"select * from products where Category='{category}'")).ToList());
            return result;
        }
    }
}
