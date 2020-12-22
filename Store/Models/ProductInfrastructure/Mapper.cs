using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Store.Models.ProductInfrastructure
{
    public class Mapper : IFormCollectionMapper
    {
        public T Map<T>(IFormCollection fieldsData) where T: Product,new()
        {
            int a;       
            T result = new();
            foreach (var i in fieldsData.Keys)
            {
                var proprety = result.GetType().GetProperty(i);
                if (proprety is null)
                    continue;
                if(proprety.PropertyType == typeof(int))
                proprety.SetValue(result, int.TryParse(fieldsData[i].First()?.ToString(),out a)? int.Parse(fieldsData[i].First()?.ToString()):0);
                else
                proprety.SetValue(result, fieldsData[i].First()?.ToString()??default);
            }
            return result;
        }
    }
}
