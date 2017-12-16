﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using DevaxiloS.Infras.Common.Enums;
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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Picture { get; set; }
        public string PasswordHash { get; set; }
        public SysStatus UserStatus { get; set; }
        public string Expired { get; set; }
        public string Roles { get; set; }
        public string OrganisationId { get; set; }
        public string OrganisationName { get; set; }
        public string GroupId { get; set; }
        public string GroupName { get; set; }
    }

    public static class UserExtended
    {
        public static int GetUserDbId(this IPrincipal user)
        {

            var claim = ((ClaimsIdentity)user.Identity).FindFirst("UserDbId");
            return int.Parse(claim?.Value);
        }

        public static string GetEmail(this IPrincipal user)
        {

            var claim = ((ClaimsIdentity)user.Identity).FindFirst(ClaimTypes.Email);
            return claim?.Value;
        }

        public static string GetPasswordHash(this IPrincipal user)
        {
            var claim = ((ClaimsIdentity)user.Identity).FindFirst("PasswordHash");
            return claim?.Value;
        }

        public static string GetUserId(this IPrincipal user)
        {
            var claim = ((ClaimsIdentity)user.Identity).FindFirst("UserId");
            return claim?.Value;
        }

        public static string GetFirstName(this IPrincipal user)
        {
            var claim = ((ClaimsIdentity)user.Identity).FindFirst("FirstName");
            return claim?.Value;
        }
        public static string GetLastName(this IPrincipal user)
        {
            var claim = ((ClaimsIdentity)user.Identity).FindFirst("LastName");
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
            throw new NotImplementedException();
            //if (string.IsNullOrWhiteSpace(userName))
            //    throw new ArgumentNullException(nameof(userName));
            //var cmdBus = ServiceLocator.Services.CommandBus;
            //var cmd = new CheckUserLoginCommand(0, userName);
            //cmdBus.Send(cmd);
            //var user = cmd.Response.ResponseObj;
            //var task = Task<AspnetIdentityUser>.Factory.StartNew(() =>
            //{
            //    if (user == null)
            //        return new AspnetIdentityUser();
            //    return new AspnetIdentityUser
            //    {
            //        UserDbId = user.Id,
            //        Email = user.Email,
            //        UserName = user.Email,
            //        PasswordHash = user.PasswordHash,
            //        FirstName = user.FirstName,
            //        LastName = user.LastName,
            //        Expired = (user.ExpiredAt.HasValue && user.ExpiredAt.Value < DateTime.UtcNow) ? "1" : "0",
            //        UserStatus = user.UserStatus,
            //        UserId = user.UserId,
            //        Roles = user.Roles,
            //        OrganisationId = user.OrganisationId.HasValue ? user.OrganisationId.ToString() : string.Empty,
            //        OrganisationName = user.OrganisationName,
            //        GroupId = user.GroupId.HasValue ? user.GroupId.ToString() : string.Empty,
            //        GroupName = user.GroupName
            //    };
            //});
            //return task;
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