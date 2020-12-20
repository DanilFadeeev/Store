using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models.ProductInfrastructure
{
    interface ISaver
    {
        void Save(IFormCollection data );
    }
}
