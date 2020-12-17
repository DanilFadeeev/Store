using Dapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Store.Models;
using Store.Models.IdentityInfrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;


namespace Store.Data
{
    //TODO: change connectionstring name ShopTest to Shop
    public class UserRepository : IUserStore<User>, IUserEmailStore<User>, IRoleStore<Role>, IUserPasswordStore<User>, IUserPhoneNumberStore<User>,
    IUserTwoFactorStore<User>, IUserRoleStore<User>
    {
        public string ConnectionString { get; set; }

        public UserRepository(IConfiguration configuration = null)
        {
            ConnectionString = configuration.GetConnectionString("ShopTest");
            if (ConnectionString is null)
                ConnectionString = "server=.\\SQLEXPRESS;database=ShopTest;Trusted_Connection=true";
        }
        public async Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            ValidationContext context = new(user);
            List<ValidationResult> results = new();
            if (!Validator.TryValidateObject(user, context, results))
                return IdentityResult.Failed();

            using SqlConnection conn = new(ConnectionString);
            user.UserId = Guid.NewGuid().ToString();
            var res = await conn.ExecuteAsync("Insert Into Users values(@UserId,@Email,@PhoneNumber,@UserName,@Password)", user);
            if (res == 1)
                return IdentityResult.Success;
            return IdentityResult.Failed();
        }

        public async Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            try
            {
                using SqlConnection conn = new(ConnectionString);
                var Id = await conn.QuerySingleAsync<string>("Select UserId from Users where Email = @Email", user);
                return Id;
            }
            catch { return ""; }
        }

        public async Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            try
            {
                using SqlConnection conn = new(ConnectionString);
                var name = await conn.QuerySingleAsync<string>("Select UserName from Users where Email = @Email", user);
                return name;
            }
            catch { return ""; }
        }

        public async Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            using SqlConnection conn = new(ConnectionString);
            await conn.ExecuteAsync($"update users set UserName='{userName}' where Email = @Email", user);
            user.UserName = userName;
        }

        public async Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            return (await GetUserNameAsync(user, cancellationToken)).ToUpper();
        }

        public async Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            await SetUserNameAsync(user, normalizedName, cancellationToken);
            user.UserName = normalizedName;
        }


        public async Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            SqlConnection conn = new(ConnectionString);
            await conn.ExecuteAsync($"update users set Email = @Email, Phonenumber =@PhoneNumber where UserName=@UserName", user);
            return IdentityResult.Success;

        }

        public async Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            SqlConnection conn = new(ConnectionString);
            await conn.ExecuteAsync($"delete from users where UserName=@UserName", user);
            return IdentityResult.Success;
        }

        public async Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            using SqlConnection conn = new(ConnectionString);
            var user = await conn.QuerySingleAsync<User>($"Select * from Users where UserId = '{userId}'");
            return user;
        }

        public async Task<User> FindByNameAsync(string userName, CancellationToken cancellationToken)
        {
            using SqlConnection conn = new(ConnectionString);
            var user = await conn.QuerySingleAsync<User>($"Select * from Users where UserName = '{userName}'");
            return user;
        }

        public void Dispose()
        {
            return;
        }

        public async Task SetEmailAsync(User user, string email, CancellationToken cancellationToken)
        {
            SqlConnection conn = new(ConnectionString);
            await conn.ExecuteAsync($"update users set Email = '{email}' where UserName=@UserName", user);
            return;
        }

        public async Task<string> GetEmailAsync(User user, CancellationToken cancellationToken)
        {
            try
            {
                using SqlConnection conn = new(ConnectionString);
                var name = await conn.QuerySingleAsync<string>("Select Email from Users where UserName = @UserName", user);
                return name;
            }
            catch { return ""; }
        }

        public async Task<bool> GetEmailConfirmedAsync(User user, CancellationToken cancellationToken)
        {
            //TODO
            return true;
        }

        public async Task SetEmailConfirmedAsync(User user, bool confirmed, CancellationToken cancellationToken)
        {
            //TODO
            return;
        }

        public async Task<User> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            using SqlConnection conn = new(ConnectionString);
            var user = await conn.QuerySingleAsync<User>($"Select * from Users where Email = '{normalizedEmail}'");
            return user;
        }

        public async Task<string> GetNormalizedEmailAsync(User user, CancellationToken cancellationToken)
        {
            return (await FindByNameAsync(user.UserName, cancellationToken)).Email.ToUpper();
        }

        public async Task SetNormalizedEmailAsync(User user, string normalizedEmail, CancellationToken cancellationToken)
        {
            using SqlConnection conn = new(ConnectionString);
            await conn.ExecuteAsync($"update users set Email = '{normalizedEmail}' where UserName=@UserName", user);
        }

        public async Task<IdentityResult> CreateAsync(Role role, CancellationToken cancellationToken)
        {
            role.Id = Guid.NewGuid().ToString();
            SqlConnection conn = new(ConnectionString);
            var res = await conn.ExecuteAsync("Insert into Roles values(@Id,@Name);", role);
            if (res == 1)
                return IdentityResult.Success;
            return IdentityResult.Failed();

        }

        public async Task<IdentityResult> UpdateAsync(Role role, CancellationToken cancellationToken)
        {
            SqlConnection conn = new(ConnectionString);
            var res = await conn.ExecuteAsync("update Roles set Name=@Name where Id = @Id", role);
            if (res == 1)
                return IdentityResult.Success;
            return IdentityResult.Failed();
        }

        public async Task<IdentityResult> DeleteAsync(Role role, CancellationToken cancellationToken)
        {
            SqlConnection conn = new(ConnectionString);
            var res = await conn.ExecuteAsync("Delete Roles where Name = @Name", role);
            if (res == 1)
                return IdentityResult.Success;
            return IdentityResult.Failed();
        }

        public async Task<string> GetRoleIdAsync(Role role, CancellationToken cancellationToken)
        {
            using SqlConnection conn = new(ConnectionString);
            var Id = await conn.QuerySingleAsync<string>($"Select Id from Roles where Name = '{role.Name}'");
            role.Id = Id;
            return Id;
        }

        public async Task<string> GetRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            using SqlConnection conn = new(ConnectionString);
            var roleName = await conn.QuerySingleAsync<string>($"Select Name from Roles where Id = '{role.Id}'");
            role.Name = roleName;
            return roleName;
        }

        public async Task SetRoleNameAsync(Role role, string roleName, CancellationToken cancellationToken)
        {
            using SqlConnection conn = new(ConnectionString);
            var res = await conn.ExecuteAsync($"update roles set Name = '{roleName}' where Id = '{role.Id}'");
            role.Name = roleName;

        }

        public async Task<string> GetNormalizedRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task SetNormalizedRoleNameAsync(Role role, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        async Task<Role> IRoleStore<Role>.FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            using SqlConnection conn = new(ConnectionString);
            var role = await conn.QuerySingleAsync<Role>($"Select * from Roles where Id = '{roleId}'");
            return role;
        }

        async Task<Role> IRoleStore<Role>.FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            using SqlConnection conn = new(ConnectionString);
            var role = await conn.QuerySingleAsync<Role>($"Select * from Roles where Name = '{normalizedRoleName}'");
            return role;
        }

        public async Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
        {
            SqlConnection conn = new(ConnectionString);
            var res = await conn.ExecuteAsync($"update Users set PasswordHash = '{passwordHash}' where UserId = '{user.UserId}'");
            user.Password = passwordHash;
        }

        public async Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
        {
            using SqlConnection conn = new(ConnectionString);
            var role = await conn.QuerySingleAsync<string>($"Select PasswordHash from Users where UserId = '{user.UserId}'");
            return role;
        }

        public async Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
        {
            try
            {
                await GetPasswordHashAsync(user, cancellationToken);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task SetPhoneNumberAsync(User user, string phoneNumber, CancellationToken cancellationToken)
        {
            using SqlConnection conn = new(ConnectionString);
            var res = await conn.ExecuteAsync($"update Users set UserPhone = '{phoneNumber}' where Id = '{user.UserId}'");
            user.PhoneNumber = phoneNumber;
        }

        public async Task<string> GetPhoneNumberAsync(User user, CancellationToken cancellationToken)
        {
            using SqlConnection conn = new(ConnectionString);
            var role = await conn.QuerySingleAsync<string>($"Select PhoeNumber from Users where Id = '{user.UserId}'");
            return role;
        }

        public Task<bool> GetPhoneNumberConfirmedAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetPhoneNumberConfirmedAsync(User user, bool confirmed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetTwoFactorEnabledAsync(User user, bool enabled, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetTwoFactorEnabledAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }




        public async Task AddToRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            using SqlConnection conn = new(ConnectionString);
            Role role = await ((IRoleStore<Role>)this).FindByNameAsync(roleName, cancellationToken);
            await conn.ExecuteAsync($"Insert into UserRole values('{user.UserId}','{role.Id}');");
        }

        public async Task RemoveFromRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            using SqlConnection conn = new(ConnectionString);
            Role role = await ((IRoleStore<Role>)this).FindByNameAsync(roleName, cancellationToken);
            await conn.ExecuteAsync($"delete from UserRole where UserId='{user.UserId}' and RoleId='{role.Id}'");
        }

        public async Task<IList<string>> GetRolesAsync(User user, CancellationToken cancellationToken)
        {
            using SqlConnection conn = new(ConnectionString);
            string sql = $"select name from Roles join UserRole on Roles.id = UserRole.RoleId and UserRole.UserId = '{user.UserId}'";
            var result = (await conn.QueryAsync<string>(sql)).ToList() ;
            return result;
        }

        public async Task<bool> IsInRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            var userRoles = await GetRolesAsync(user,cancellationToken);
            foreach (var r in userRoles)
                if (r == roleName)
                    return true;
            return false;
        }

        public async Task<IList<User>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            using SqlConnection conn = new(ConnectionString);
            Role role = await ((IRoleStore<Role>)this).FindByNameAsync(roleName, cancellationToken);
            string sql = $@"select Users.UserId, Email, PhoneNumber, UserName, PasswordHash as Password from Users 
                            join UserRole
                        on Users.UserId = UserRole.UserId and UserRole.RoleId = '{role.Id}'";
            var result = (await conn.QueryAsync<User>(sql)).ToList();
            return result;
        }
    }
}
