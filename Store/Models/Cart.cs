using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class Cart
    {
        public static Cart GetCartFromSession(IServiceProvider services)
        {
            var session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            Cart result = session.Get<Cart>("Cart") ?? new Cart();
            return result;
        }
        public List<CartItem> Products { get; set; }
        public void Add(string productId, int quantity)
        {

        }
    }

    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
