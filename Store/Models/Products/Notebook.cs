using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models.Products
{
    public class Notebook:Electronics
    {
        public int Cores { get; set; }
        public string Resolution { get; set; }
        public string VideoCard { get; set; }
    }
}
