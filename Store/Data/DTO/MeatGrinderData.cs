using Microsoft.AspNetCore.Http;
using Store.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Data.DTO
{
    public class RefrigeratorData : Refrigerator
    {
        public IFormFile ImageFile { get; set; }
    }
    public class NotebookData : Notebook
    {
        public IFormFile ImageFile { get; set; }
    }
    public class SmartphoneData : Smartphone
    {
        public IFormFile ImageFile { get; set; }
    }
    public class VacuumCleanerData : VacuumCleaner
    {
        public IFormFile ImageFile { get; set; }
    }
    public class MeatGrinderData : MeatGrinder
    {
        public IFormFile ImageFile { get; set; }
    }
}
