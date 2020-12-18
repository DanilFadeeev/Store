using Dapper;
using Store.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private string connectionString { get; }
        public CategoryRepository(IConnectionStringProvider Connection)
        {
            connectionString = Connection.ConnectionString;
        }

        public async Task<List<string>> AllCategories()
        {
            using SqlConnection conn = new(connectionString);
            var result = (await conn.QueryAsync<string>("select name from Categories")).ToList();
            return result;
        }

        public Task<List<string>> GetChildCategories(string category)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsParentCategory(string compare, string parent)
        {
            throw new NotImplementedException();
        }
    }
}
