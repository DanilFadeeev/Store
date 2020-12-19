using Store.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Data.DTO
{
    public class SignInData
    {
        [Required(ErrorMessage ="please enter email")]
        [EmailAddress(ErrorMessage = "please enter correct email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "please enter a password")]
        public string Password { get; set; }

    }
}
