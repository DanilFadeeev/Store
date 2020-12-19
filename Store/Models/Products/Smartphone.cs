using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models.Products
{
    public class Smartphone:Electronics
    {
        public string Resolution { get; set; }
        public int Cores { get; set; }
        public int BatteryVolume { get; set; }
        public string CorpusType { get; set; }
    }
}
