using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models.ProductInfrastructure
{
    public class ProductPhotoSaver : IProductPhotoSaver
    {
        public IWebHostEnvironment Env { get; }
        public ProductPhotoSaver(IWebHostEnvironment env)
        {
            Env = env;
        }


        public void Save(IFormCollection data, Product obj)
        {
            if (data.Files.Count == 0)
                return;
            var file = data.Files.First();

            string fileName = Guid.NewGuid().ToString();
            string extension = Path.GetExtension(file.FileName);

            string fullPath = Env.WebRootPath + $"\\Images\\" + fileName + extension;

            using (FileStream fs = new(fullPath, FileMode.Create))
                file.CopyToAsync(fs).Wait();

            obj.Image = $"\\Images\\" + fileName + extension;
        }
    }
}
