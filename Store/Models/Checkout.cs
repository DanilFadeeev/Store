using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class Checkout
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        [DisplayName("apartment number")]
        public string Apartment { get; set; }
        public DateTime DeliveryTime { get; set; }
        public Cart Cart { get; set; }
    }
}
