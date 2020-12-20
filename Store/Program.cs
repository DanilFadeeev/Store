using DbUp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Primitives;
using Store;
using Store.Data;
using Store.Models;
using Store.Models.Products;
using Store.tests;
using Store.Utils;
using System;
using System.Collections.Generic;
using System.Reflection;

//DbTests.Run();

foreach(var i in new MeatGrinder().GetType().GetProperties())
    Console.WriteLine(i.Name);

var repo = new ProductRepository(new csp(),new CategoryRepository(new csp(), new CategoryTreeProvider(new csp())));
var products = repo.GetProducts<Product>("product").Result;
foreach(var i in products)
    Console.WriteLine(i.Description);

class csp : IConnectionStringProvider
{
    public string ConnectionString => "server=.\\SQLEXPRESS;database=ShopTest;Trusted_Connection=true";
}

//CreateHostBuilder(args).Build().Run();


//static IHostBuilder CreateHostBuilder(string[] args) =>
//    Host.CreateDefaultBuilder(args)
//        .ConfigureWebHostDefaults(webBuilder =>
//        {
//            webBuilder.UseStartup<Startup>();
//        });

