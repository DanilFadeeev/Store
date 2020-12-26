using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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
        public string Comment { get; set; }
        public override string ToString()
        {
            StringBuilder result = new();
            result.Append($"City: {City}\n");
            result.Append($"Street: {Street}\n");
            result.Append($"House: {House}\n");
            result.Append($"Apartment: {Apartment}\n");
            result.Append($"DeliveryTime: {DeliveryTime}\n");
            result.Append($"Comment: {Comment}\n");
            foreach (var i in Cart.ProductsWithQuantity)
                result.Append($"product: {i.Product.Name}(id = {i.Product.Id}) Quantity: {i.Quantity}\n");
            return result.ToString();
        }
    }
}
