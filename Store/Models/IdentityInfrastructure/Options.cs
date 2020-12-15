using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models.IdentityInfrastructure
{
    public class Options : IOptions<IdentityOptions>
    {
        public IdentityOptions Value { get; set; }
        public Options() { Value = new IdentityOptions(); }
    }
}
