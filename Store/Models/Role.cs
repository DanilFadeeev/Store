using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class Role: IRole
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
