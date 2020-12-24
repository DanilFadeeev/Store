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
        public async Task<List<T>> GetProductsAsync<T>(string category) where T : Product
        {
            SqlConnection conn = new(ConnectionString);
            List<T> result = new();
            foreach (var c in await Repo.GetNotAbstractChildren(category))
                result.AddRange((await conn.QueryAsync<T>($"select * from products where Category='{c}'")).ToList());
            result.AddRange((await conn.QueryAsync<T>($"select * from products where Category='{category}'")).ToList());
            return result;
        }

        public async Task<List<Product>> GetProductsWithSalersAsync(string category) 
        {
            SqlConnection conn = new(ConnectionString);
            var result = (await conn.QueryAsync<Product, User, Product>("exec GetProductsWithSalers;",
                (product, user) =>
                {
                    product.Saler = user;
                    return product;
                },
                splitOn: "UserName"
                ))
                .ToList()
                .Where(p=> p.Category == category ||  Repo.GetChildrenCategories(category).Result.Contains(p.Category))
                .ToList();
            return result;
        }

        public async Task<Product> GetPRoductById(int productId)
        {
            SqlConnection conn = new(ConnectionString);
            var result = await conn.QuerySingleAsync<Product>($"select * from products where Id = '{productId}'");
            return result;
        }

        public async Task<Product> GetProductWithSalerById(int productId)
        {
            SqlConnection conn = new(ConnectionString);
            var result = (await conn.QueryAsync<Product, User, Product>($"exec GetProductWithSalerByProductId {productId}",
                (product, user) =>
                {
                    product.Saler = user;
                    return product;
                },
                splitOn: "UserName"
                )).FirstOrDefault();
            return result;
        }


    }
}
