using Dapper;
using Microsoft.AspNetCore.Http;
using Store.Models.Products;
using Store.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models.ProductInfrastructure
{
    public class ProductSaver : IProductSaver
    {
        public IFormCollectionMapper Mapper { get; }
        public IInsertSqlComandProvider Sql { get; }
        public IProductPhotoSaver PhotoSaver { get; }
        public IConnectionStringProvider ConnectionStringProvider { get; }

        public ProductSaver(IFormCollectionMapper mapper, IInsertSqlComandProvider sql, IProductPhotoSaver photoSaver, IConnectionStringProvider connectionStringProvider)
        {
            Mapper = mapper;
            Sql = sql;
            PhotoSaver = photoSaver;
            ConnectionStringProvider = connectionStringProvider;
        }


        public void Save(IFormCollection data)
        {
            Product result=null;
            if (data["Category"] == "meatGrinder")
                result = Mapper.Map<MeatGrinder>(data);
            PhotoSaver.Save(data, result);

            SqlConnection conn = new(ConnectionStringProvider.ConnectionString);
            conn.Execute(Sql.GetCommand(result), result);
        }
    }
}
