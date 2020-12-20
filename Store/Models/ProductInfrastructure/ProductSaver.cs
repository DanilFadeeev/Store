using Microsoft.AspNetCore.Http;
using Store.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models.ProductInfrastructure
{
    public class ProductSaver : ISaver
    {
        public IFormCollectionMapper Mapper { get; }
        public IInsertSqlComandProvider Sql { get; }

        public ProductSaver(IFormCollectionMapper mapper, IInsertSqlComandProvider sql)
        {
            Mapper = mapper;
            Sql = sql;
        }


        public void Save(IFormCollection data)
        {
            object result;
            if (data["Category"] == "meatGrinder")
                result = Mapper.Map<MeatGrinder>(data);
        }
    }
}
