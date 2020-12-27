using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Data;
using Store.Models;
using Store.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers
{
    public class ProductController : Controller
    {
        public ICategoryRepository CategoryRepo { get; }
        public IProductRepository ProductRepository { get; }

        public ProductController(ICategoryRepository categoryRepo, IProductRepository productRepository)
        {
            CategoryRepo = categoryRepo;
            ProductRepository = productRepository;
        }
        public IActionResult AllProducts(string category)
        {
            var result = ProductRepository.GetProductsWithSalersAsync(category ?? "product").Result;
            return View(result);
        }
        public IActionResult ShowProductInfo(int productId)
        {

            var data = ProductRepository.GetProductById(productId).Result;
            Product Model = null;
            if (data is null)
                return NotFound();

            if (data.Category == "meatGrinder")
                Model = ProductRepository.GetProductById<MeatGrinder>(data.Id).Result;
            if (data.Category == "notebook")
                Model = ProductRepository.GetProductById<Notebook>(data.Id).Result;
            if (data.Category == "refrigerator")
                Model = ProductRepository.GetProductById<Refrigerator>(data.Id).Result;
            if (data.Category == "smartphone")
                Model = ProductRepository.GetProductById<Smartphone>(data.Id).Result;
            if (data.Category == "vacuumCleaner")
                Model = ProductRepository.GetProductById<VacuumCleaner>(data.Id).Result;

            if(Model is not null)
                return View(data.Category, Model);


            return NotFound();
        }
    }
}
