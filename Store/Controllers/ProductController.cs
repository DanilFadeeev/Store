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

        public ProductController(ICategoryRepository categoryRepo)
        {
            CategoryRepo = categoryRepo;
        }
        public IActionResult MeatGrinder()
        {
            MeatGrinder model = new()
            {
                Id = 8,
                Cost = 100,
                Category = "meat grinder",
                Brand = "hoshiba",
                Country = "Italy",
                Name = "oleriky",
                PowerInWatt = 2000,
                ProductivityKgPerMin = 2,
                WeightInGrams = 1700,
                Description = "perfect meat grinder for your kitchen"
            };
            return View(model);
        }
        public IActionResult Notebook()
        {
            Notebook model = new()
            {
                Category = "Notebook",
                Cores = 4,
                Cost = 10000,
                Name = "deleter 4 pro",
                Resolution = "3840x2420",
                VideoCard = "RTX 2080 ti",
                ScreenSize = 16,
                Description = "top laptop"
            };
            return View(model);
        }
        public IActionResult Refrigerator()
        {
            Refrigerator model = new()
            {
                Category = "refrigerator",
                Color = "solid grey",
                Brand = "yamaha",
                HeightMm = 434,
                WidthMm = 111,
                LengthMm = 666,
                Name = "holodos 3000",
                Cost = 12345,
                PowerInWatt = 500,
                VolumeLiters = 130,
                Description = "this thing designed by Edel Michelov"
            };
            return View(model);
        }
        public IActionResult Smartphone()
        {
            Smartphone model = new()
            {
                Name = "galaxy m2",
                BatteryVolume = 3400,
                Cores = 8,
                CorpusType = "solid metall",
                Resolution = "156x620",
                Description = "best smartphone for new year gift"
            };
            return View(model);
        }
   
    
    }
}
