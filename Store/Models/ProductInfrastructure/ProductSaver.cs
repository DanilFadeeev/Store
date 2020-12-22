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
        public void Save(IFormCollection formData)
        {
            Product result=null;

            string type = formData["category"].ToString();
            if (type == "notebook")
                result = Mapper.Map<Notebook>(formData);
            if (type == "refrigerator")
                result = Mapper.Map<Refrigerator>(formData);
            if (type == "meatGrinder")
                result = Mapper.Map<MeatGrinder>(formData);
            if (type == "smartphone")
                result = Mapper.Map<Smartphone>(formData);
            if (type == "vacuumCleaner")
                result = Mapper.Map<VacuumCleaner>(formData);

            PhotoSaver.Save(formData, result);

            SqlConnection conn = new(ConnectionStringProvider.ConnectionString);
            conn.Execute(Sql.GetCommand(result), result);
        }
    }
}
