using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Utils
{
    public static class UserExtension
    {
        public static string GetUserDataForEmailMessage(this User user)
        {
            return $"name: {user.UserName}\n" +
                $"email: {user.Email}\n" +
                $"phone: {user.PhoneNumber}";
        }
    }
}
