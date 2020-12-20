using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models.Products
{
    public class MeatGrinder:Appliance
    {
        static public string ProductName = "meatGrinder";
        public int ProductivityKgPerMin { get; set; }
        public string Country { get; set; }
        public int WeightInGrams { get; set; }
    }
}
