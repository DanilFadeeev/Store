﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Data.DTO;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Store.Utils;
using System.Threading.Tasks;

namespace Store.Controllers
{
    public class AccountController : Controller
    {
        public UserManager<User> UserManager { get; }
        public SignInManager<User> SignInManager { get; }

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public async Task<IActionResult> Login(string returnUrl = null)
        {
            ViewData["returnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(SignInData data, string returnUrl = null)
        {
            ViewData["returnUrl"] = returnUrl;
            if (!ModelState.IsValid)
                return View(data);

            User corr = await UserManager.FindByEmailAsync(data.Email);
            if (corr?.Password == data?.Password)
            {
                await SignInManager.SignInAsync(corr, false);
                return Redirect(returnUrl ?? "/");
            }
            return View(data);

        }
        public async Task<IActionResult> SignUp(string returnUrl = null)
        {
            ViewData["returnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp( SignUpData data, string returnUrl)
        {
            if (!ModelState.IsValid)
                return View(data);

         var res =   await UserManager.CreateAsync(data.ToUser());
            if (!res.Succeeded)
            {
                ViewData["returnUrl"] = returnUrl;
                return View(data);
            }
            return Redirect(returnUrl?? "/");
        }

    }
}
