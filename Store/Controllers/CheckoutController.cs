using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Models;
using Store.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Store.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        public IActionResult Checkout([FromServices] Cart cartService)
        {
            Checkout order = new() { Cart = cartService };
            return View(order);
        }
        [HttpPost]
        public IActionResult Checkout(Checkout order, [FromServices] Cart cart, [FromServices] UserManager<User> usermanager)
        {
            order.Cart = cart;
            var fromAddress = new MailAddress("fdanya0@gmail.com");
            var toAddress = new MailAddress("daniil-fadeev@bk.ru");
            string fromPassword = Environment.GetEnvironmentVariable("password");
            string subject = "new order";
            User u = usermanager.FindByNameAsync(User.Identity.Name).Result;
            string body = u.GetUserDataForEmailMessage() + "\n" + order.ToString();

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            };

            smtp.Send(message);
            cart.Clear();
            return Redirect("/");
        }
    }
}
