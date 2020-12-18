using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models.Products
{
    public class Refrigerator:Appliance
    {
        public string Color { get; set; }
        public int LengthMm { get; set; }
        public int WidthMm { get; set; }
        public int HeightMm { get; set; }
        public int VolumeLiters { get; set; }
    }
}
