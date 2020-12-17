using DbUp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using Store;
using Store.Data;
using Store.Models;
using Store.tests;
using System;
using System.Reflection;

//User test = new() { UserId = "a", UserName = "a" };
////new UserRepository().AddToRoleAsync(test, "con",new()).Wait();

//var roles =  new UserRepository().GetRolesAsync(test, new()).Result ;

//foreach (var i in roles)
//    Console.WriteLine(i) ;


//var users = new UserRepository().GetUsersInRoleAsync("god user", new()).Result;
//foreach (var u in users)
//    Console.WriteLine(u.Email + " " + u.UserName);
//DbTests.Run();

CreateHostBuilder(args).Build().Run();


static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });


