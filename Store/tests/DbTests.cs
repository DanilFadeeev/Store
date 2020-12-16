using DbUp;
using Microsoft.AspNetCore.Identity;
using Store.Data;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Store.tests
{
    public class DbTests
    {
        public static void Run()
        {
            var connectionString = "server=.\\SQLEXPRESS;database=ShopTest;Trusted_Connection=true";
            EnsureDatabase.For.SqlDatabase(connectionString);
            var upgrader =
            DeployChanges.To
            .SqlDatabase(connectionString)
            .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
            .LogToConsole()
            .Build();

            var scripts = upgrader.GetScriptsToExecute();
            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();

            }
            else
            {

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Success!");
                Console.ResetColor();
            }

            Role test = new() { Name = "test" };
            IRoleStore<Role> store = new UserRepository() { ConnectionString = connectionString };

            Console.WriteLine("creating new role...");
            store.CreateAsync(test, new()).Wait();

            Console.WriteLine("Find Role by Name");
            Console.WriteLine("created role id: " + store.FindByNameAsync("test", new()).Result.Id);
            test = store.FindByNameAsync("test", new()).Result;

            Console.WriteLine("change Role name to Admin...");
            store.SetRoleNameAsync(test, "Admin", new()).Wait();

            Console.WriteLine("Find Role by Id");
            Console.WriteLine("Changed role Name:  " + store.FindByIdAsync(test.Id, new()).Result.Name);
            test = store.FindByIdAsync(test.Id, new()).Result;

            Console.WriteLine("Delete role");
            store.DeleteAsync(test, new()).Wait();

            Console.WriteLine("try get deleted role");
            try
            {
                test = store.FindByNameAsync(test.Name, new()).Result;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(e);
                Console.ResetColor();
            }


            User user = new() { Email = "new@mail.ru", PhoneNumber = "88005553535", UserName = "maximilyan", Password = "password" };
            UserRepository repo = new() { ConnectionString = connectionString };

            var c = repo.CreateAsync(user,
            new()).Result;


            Console.WriteLine(c);

            Console.WriteLine("get user Id async");
            Console.WriteLine(repo.GetUserIdAsync(user, new()).Result);


            Console.WriteLine("get user name");
            Console.WriteLine(repo.GetUserNameAsync(user, new()).Result);

            Console.WriteLine("set user name to defaultName...");
            repo.SetUserNameAsync(user, "defaultName", new()).Wait();

            Console.WriteLine("get user name again");
            Console.WriteLine(repo.GetUserNameAsync(user, new()).Result);
            user.UserName = repo.GetUserNameAsync(user, new()).Result;

            Console.WriteLine("find user by name and print email");
            Console.WriteLine(repo.FindByNameAsync("defaultName", new()).Result.Email);

            Console.WriteLine("change Email");
            repo.SetEmailAsync(user, "changed@mail.ru", new()).Wait();

            Console.WriteLine("find user by name and print email");
            Console.WriteLine(repo.FindByNameAsync("defaultName", new()).Result.Email);

            Console.WriteLine("Delete user named defaultName");
            var u = repo.FindByNameAsync("defaultName", new()).Result;
            repo.DeleteAsync(u, new()).Wait();

            Console.WriteLine("try to get deleted user");
            try
            {
                Console.WriteLine(repo.FindByEmailAsync(u.UserName, new()).Result);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(e);
                Console.ResetColor();
            }


            Console.WriteLine("start testing IPassordStore");
            User user1 = new() { Email = "PasswordTEst@mail.ru", PhoneNumber = "71002348-5325", UserName = "PasswordMan", Password = "Default" };
            IUserPasswordStore<User> repo1 = new UserRepository() { ConnectionString = connectionString };

            var res = repo1.CreateAsync(user1,
            new()).Result;


            Console.WriteLine(res);
            Console.WriteLine("Users first passowrd: ");
            Console.WriteLine(repo1.GetPasswordHashAsync(user1,new()).Result);

            Console.WriteLine("change password to 123456");
            repo1.SetPasswordHashAsync(user1, "123456", new()).Wait();

            Console.WriteLine("show new password");
            Console.WriteLine(repo1.GetPasswordHashAsync(user1,new()).Result);

        }
    }
}
