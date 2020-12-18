using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Utils
{
    public class TestConnectionStringProvider : IConnectionStringProvider
    {
        public TestConnectionStringProvider(IConfiguration config)
        {
           ConnectionString =  config.GetConnectionString("ShopTest");
        }
        public string ConnectionString { get; }
    }
}
