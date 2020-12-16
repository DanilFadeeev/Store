using DbUp;
using Microsoft.AspNetCore.Identity;
using Store.Data;
using Store.Models;
using Store.tests;
using System;
using System.Reflection;


DbTests.Run();

//CreateHostBuilder(args).Build().Run();


//static IHostBuilder CreateHostBuilder(string[] args) =>
//    Host.CreateDefaultBuilder(args)
//        .ConfigureWebHostDefaults(webBuilder =>
//        {
//            webBuilder.UseStartup<Startup>();
//        });


