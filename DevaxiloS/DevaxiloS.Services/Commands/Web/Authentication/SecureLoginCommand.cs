using System;
using System.Linq;
using System.Threading.Tasks;
using DevaxiloS.DataAccess.MsSql.EntityFramework;
using DevaxiloS.Infras.Commands;
using DevaxiloS.Infras.Common.Enums;
using DevaxiloS.Infras.Messaging;
using DevaxiloS.Services.DomainModels.Customer;

namespace DevaxiloS.Services.Commands.Web.Authentication
{
    public class SecureLoginCommand : Command
    {
        public UserValidationRequest Request { get; }

        public CommandResponse<bool> Response { get; set; }

        public SecureLoginCommand(int id, UserValidationRequest request) : base(id)
        {
            Request = request;
        }
    }

    public class SecureLoginCommandHandler : ICommandHandler<SecureLoginCommand>
    {
        public async Task Execute(SecureLoginCommand command)
        {
            var request = command.Request;
            using (var context = new DevaxiloContext())
            {
                var user = context.Accounts.SingleOrDefault(x => x.Email.Equals(request.Email));
                if (user == null)
                {
                    command.Response = new CommandResponse<bool>(false, true, "Account not exist.");
                    return;
                }
                
                if(user.Status == (byte)SysStatus.Deleted)
                {
                    command.Response = new CommandResponse<bool>(false, true, "Account is blocked.");
                    return;
                }

                var dnow = DateTime.UtcNow;
                var login = context.AccountLogin.SingleOrDefault(x => x.HashLoginCode.Equals(request.Skey) && x.ExpiredAt > dnow);

                if (login == null)
                {
                    command.Response = new CommandResponse<bool>(false, true, "Login expired");
                    return;
                }

                if (user.Status == (byte) SysStatus.New)
                {
                    user.Status = (byte) SysStatus.Activated;
                    var accBalance = new AccountBalance
                    {
                        Balance = 0,
                        HoldBalance = 0,
                        AccId = user.Id,
                        Status = (byte) SysStatus.Activated
                    };

                    context.AccountBalances.Add(accBalance);
                    await context.SaveChangesAsync();
                }

                command.Response = new CommandResponse<bool>(true);
            }
        }
    }
}
