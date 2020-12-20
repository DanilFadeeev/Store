using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models.ProductInfrastructure
{
    public class Mapper : IFormCollectionMapper
    {
        public T Map<T>(IFormCollection fieldsData) where T: Product,new()
        {
            T result = new();
            foreach (var i in fieldsData.Keys)
            {
                var proprety = result.GetType().GetProperty(i);
                if (proprety is null)
                    continue;
                proprety.SetValue(result, fieldsData[i].First()?.ToString()??default);
            }
            return result;
        }
    }
}
