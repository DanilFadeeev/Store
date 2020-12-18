using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models.Products
{
    public class VacuumCleaner:Appliance
    {
        public int MaxNoizeDb { get; set; }
        public string CleaningType { get; set; }

    }
}
