﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public interface ICategoryTreeProvider
    {
        Category Root { get; }
    }
}
