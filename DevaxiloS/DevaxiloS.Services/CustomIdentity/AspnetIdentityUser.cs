using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using DevaxiloS.Infras.Common.Enums;
using DevaxiloS.Services.Commands.Web.Customer;
using DevaxiloS.Services.Configuration;
using Microsoft.AspNet.Identity;

namespace DevaxiloS.Services.CustomIdentity
{
    public class AspnetIdentityUser : IUser
    {
        public string Id => UserId.ToString();
        public int UserDbId { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public SysStatus UserStatus { get; set; }
    }

    public static class UserExtended
    {
        public static int GetUserDbId(this IPrincipal user)
        {
            var claim = ((ClaimsIdentity)user.Identity).FindFirst("UserDbId");
            return int.Parse(claim?.Value);
        }

        public static string GetUserId(this IPrincipal user)
        {
            var claim = ((ClaimsIdentity)user.Identity).FindFirst("UserId");
            return claim?.Value;
        }

        public static string GetEmail(this IPrincipal user)
        {
            var claim = ((ClaimsIdentity)user.Identity).FindFirst(ClaimTypes.Email);
            return claim?.Value;
        }
    }

    public class UserStore : IUserStore<AspnetIdentityUser>, IUserLoginStore<AspnetIdentityUser>, IUserPasswordStore<AspnetIdentityUser>
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(AspnetIdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(AspnetIdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(AspnetIdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task<AspnetIdentityUser> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<AspnetIdentityUser> FindByNameAsync(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentNullException(nameof(userName));
            var cmdBus = ServiceLocator.Services.CommandBus;
            var cmd = new CheckUserLoginCommand(0, userName);
            cmdBus.Send(cmd);
            var user = cmd.Response.ResponseObj;
            var task = Task<AspnetIdentityUser>.Factory.StartNew(() =>
            {
                if (user == null)
                    return new AspnetIdentityUser();
                return new AspnetIdentityUser
                {
                    UserDbId = user.Id,
                    Email = user.Email,
                    UserName = user.Email,
                    PasswordHash = user.PasswordHash,
                    UserStatus = user.UserStatus,
                    UserId = user.UserId,
                };
            });
            return task;
        }

        public Task AddLoginAsync(AspnetIdentityUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task RemoveLoginAsync(AspnetIdentityUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(AspnetIdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task<AspnetIdentityUser> FindAsync(UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(AspnetIdentityUser user, string passwordHash)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            user.PasswordHash = passwordHash;
            return Task.FromResult(0);
        }

        public Task<string> GetPasswordHashAsync(AspnetIdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(AspnetIdentityUser user)
        {
            return Task.FromResult(!string.IsNullOrEmpty(user.PasswordHash));
        }
    }
}