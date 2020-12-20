using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models.ProductInfrastructure
{
    public interface IFormCollectionMapper
    {
        T Map<T>(IFormCollection data) where T:Product, new();
    }
}
