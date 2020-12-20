using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models.ProductInfrastructure
{
    public class InsertSqlComandProvider : IInsertSqlComandProvider
    {
        public string GetCommand(object data)
        {

            StringBuilder sql = new StringBuilder();
            sql.Append("insert into Products(");
            foreach (var i in data.GetType().GetProperties())
            {
                if (i.Name == "Saler"||"Id"==i.Name)
                    continue;
                if (i.Name == "SalerId")
                    sql.Append("UserId");
                else
                    sql.Append(i.Name);
                sql.Append(",");
            }
            sql.Remove(sql.Length - 1, 1);
            sql.Append(") values(");
            foreach (var i in data.GetType().GetProperties())
            {
                if (i.Name == "Saler" || "Id" == i.Name)
                    continue;
                sql.Append("@");
                sql.Append(i.Name);
                sql.Append(",");
            }
            sql.Remove(sql.Length - 1, 1);
            sql.Append(");");
            return sql.ToString();
        }
    }
}
