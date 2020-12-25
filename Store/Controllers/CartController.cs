using Microsoft.AspNetCore.Mvc;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers
{
    public class CartController : Controller
    {
        public CartController(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        public IProductRepository ProductRepository { get; }

        public IActionResult AddToCart(int productId, int quantity, string returnUrl, [FromServices] Cart cartService)
        {
            var isSessionCart = cartService is SessionCart;
            var product = ProductRepository.GetProductById(productId).Result;
            cartService.Add(product, quantity);
            return Redirect(returnUrl??"/");
        }
        public IActionResult RemoveFromCart(int productId, string returnUrl, [FromServices] Cart cartService)
        {
            var isSessionCart = cartService is SessionCart;
            var product = ProductRepository.GetProductById(productId).Result;
            cartService.RemoveItem(product);
            return Redirect(returnUrl ?? "/");
        }
        public IActionResult CartSummary([FromServices] Cart cartService)
        {
            return View("CartSummary", cartService);
        }
    }
}
