using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Store.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers
{
    public class AddProductController:Controller
    {
        public ICategoryRepository CategoryRepo { get; }

        public AddProductController(ICategoryRepository categoryRepo)
        {
            CategoryRepo = categoryRepo;
        }
        [HttpGet]
        public async Task<IActionResult> AddProduct(string productType = null)
        {
            var types = await CategoryRepo.GetNotAbstractChildren("product");
            ViewData["productType"] = productType;
            return View(types);
        }

        [HttpPost]
        public IActionResult addproduct(IFormCollection data)
        {
            if (data["category"].Contains("meatGrinder"))
                return View();
            //new ProductRepository().GetProducts<Product>("a");
            return View();
        }
    }
}
