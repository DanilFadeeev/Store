using Store.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    interface IProductRepository
    {
        Task<List<T>> GetProducts<T>(string category) where T: Product;
    } 
}
