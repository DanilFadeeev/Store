﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class Category
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int ParentCagegory { get; set; }
        public Category Parent { get; set; }
        public List<Category> Children { get; set; }
    }
}
