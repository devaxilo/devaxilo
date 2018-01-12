using System;
using DevaxiloS.Infras.Common.Enums;

namespace DevaxiloS.Services.DomainModels.Customer
{
    public class UserLoginResponse
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public SysStatus UserStatus { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
    }
}
