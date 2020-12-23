﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class Cart
    {

        public List<CartItem> ProductsWithQuantity { get; set; }
        virtual public void Add(Product product, int quantity)
        {
            if (ProductsWithQuantity is null)
                ProductsWithQuantity = new();

            var item = ProductsWithQuantity.Where(ci => ci.Product.Id == product.Id).FirstOrDefault();
            if (item is null)
            {
                item = new();
                item.Product = product;
                ProductsWithQuantity.Add(item);
            }
            item.Quantity += quantity;
        }
    }

    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
