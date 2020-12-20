using Microsoft.AspNetCore.Http;
using Store.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Data.DTO
{
    public class MeatGrinderData:MeatGrinder
    {
        public IFormFile ImageFile { get; set; }
    }
}
