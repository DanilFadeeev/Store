using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public UserManager<User> UserManager { get; }
        public SignInManager<User> SignInManager { get; }

        public async Task<IActionResult> Login(string returnUrl = null)
        {
            User test = new() { UserId = "a", Email = "email@.com", PhoneNumber = "12344312", UserName = "Name", Password = "strongPass!" };
            await SignInManager.SignInAsync(test, false) ;
            return View();
        }
        [Authorize(Roles = "admin")]
        public string Secret()
        {
            return "this is a secret page for admins";
        }
        [Authorize(Roles = "god user")]
        public string God()
        {
            return "this is a secret page for owner";
        }
    }
}
