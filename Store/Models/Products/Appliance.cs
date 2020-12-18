using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models.Products
{
    public class Appliance: Product
    {
        public int PowerInWatt { get; set; }
        public string Brand { get; set; }
    }
}
