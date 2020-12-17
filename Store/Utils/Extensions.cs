using Store.Data.DTO;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Utils
{
    public static class Extensions
    {
        public static User ToUser(this SignUpData data)
        {
            User result = new()
            {
                Email = data.Email,
                UserName = data.Name,
                Password = data.Password,
                PhoneNumber = data.Phone
            };
            return result;
        }

        public static User ToUser(this SignInData data)
        {
            User result = new()
            {
                Email = data.Email,
                Password = data.Password
            };
            return result;
        }
    }
}
