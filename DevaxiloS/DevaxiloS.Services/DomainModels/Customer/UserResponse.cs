﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
