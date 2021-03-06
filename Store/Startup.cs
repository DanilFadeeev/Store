using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Store.Data;
using Store.Models;
using Store.Models.ProductInfrastructure;
using Store.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;

            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables("ASPNETCORE_");
            Configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddTransient<IUserStore<User>, UserRepository>();
            services.AddTransient<IRoleStore<Role>, UserRepository>();
            services.AddSingleton<IConnectionStringProvider, TestConnectionStringProvider>();
            services.AddSingleton<ICategoryTreeProvider, CategoryTreeProvider>();
            services.AddSingleton<ICategoryRepository, CategoryRepository>();
            services.AddSingleton<IFormCollectionMapper, Mapper>();
            services.AddSingleton<IProductSaver, ProductSaver>();
            services.AddSingleton<IInsertSqlComandProvider, InsertSqlComandProvider>();
            services.AddSingleton<IProductPhotoSaver, ProductPhotoSaver>();
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));

            services.AddIdentity<User, Role>()
                .AddDefaultTokenProviders();

            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "", pattern: "{controller=Product}/{action=AllProducts}/{id?}");
            });
        }
    }
}
