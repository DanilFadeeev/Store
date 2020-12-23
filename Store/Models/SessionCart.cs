using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Store.Models
{
    public class SessionCart:Cart
    {
         public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionCart cart = session.Get<SessionCart>("cart") ?? new SessionCart();
            cart.Session = session;
            return cart;
        }
        public override void Add(Product product, int quantity)
        {
            base.Add(product, quantity);
            Session.Set("cart", this);
        }
        [JsonIgnore]
        public ISession Session { get; set; }
    }
}
