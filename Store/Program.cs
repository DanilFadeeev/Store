using DbUp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Primitives;
using Store;
using Store.Data;
using Store.Models;
using Store.tests;
using Store.Utils;
using System;
using System.Collections.Generic;
using System.Reflection;

DbTests.Run();

//CreateHostBuilder(args).Build().Run();


//static IHostBuilder CreateHostBuilder(string[] args) =>
//    Host.CreateDefaultBuilder(args)
//        .ConfigureWebHostDefaults(webBuilder =>
//        {
//            webBuilder.UseStartup<Startup>();
//        });



