using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int Cost { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SalerId { get; set; }
        public User Saler { get; set; }
        public List<Category> Categories { get; set; }

    }
}
