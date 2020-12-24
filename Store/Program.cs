using Dapper;
using DbUp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Primitives;
using Store;
using Store.Data;
using Store.Models;
using Store.Models.ProductInfrastructure;
using Store.Models.Products;
using Store.tests;
using Store.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;


CreateHostBuilder(args).Build().Run();


static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
class csp : IConnectionStringProvider
{
    public string ConnectionString => "server=.\\SQLEXPRESS;database=ShopTest;Trusted_Connection=true";
}

