using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers
{
    public class UserController : Controller
    {
        public UserManager<User> UserManager { get; }
        public UserController(UserManager<User> userManager)
        {
            UserManager = userManager;
        }

        public IActionResult ShowUserInfo(string userName)
        {
            var user = UserManager.FindByNameAsync(userName).Result;
            if (user is not null)
                return View(user);
            return NotFound();
        }
    }
}
