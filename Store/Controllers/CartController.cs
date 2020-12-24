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

        public IActionResult AddToCart(int productId, int quantity,[FromServices] Cart cartService)
        {
            var isSessionCart = cartService is SessionCart;
            var product = ProductRepository.GetPRoductById(productId).Result;
            cartService.Add(product, quantity);
            return View("CartSummary", cartService);
        }
        public IActionResult RemoveFromCart(int productId, [FromServices] Cart cartService)
        {
            var isSessionCart = cartService is SessionCart;
            var product = ProductRepository.GetPRoductById(productId).Result;
            cartService.RemoveItem(product);
            return View("CartSummary", cartService);
        }
    }
}
