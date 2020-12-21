using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models.ProductInfrastructure
{
    public interface IInsertSqlComandProvider
    {
        string GetCommand(object data);
    }
}
