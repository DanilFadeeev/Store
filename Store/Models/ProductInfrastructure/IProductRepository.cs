using Store.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public interface IProductRepository
    {
        Task<List<T>> GetProductsAsync<T>(string category) where T: Product;
        Task<List<Product>> GetProductsWithSalersAsync(string category);
        Task<Product> GetPRoductById(int productId);
        Task<Product> GetProductWithSalerById(int productId);
    }
}
