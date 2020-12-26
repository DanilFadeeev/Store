using Microsoft.AspNetCore.Mvc;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Checkout([FromServices] Cart cartService)
        {

            return View();
        }
        [HttpPost]
        public IActionResult Checkhout(Checkout order)
        {

            return Redirect("/");
        }
    }
}
