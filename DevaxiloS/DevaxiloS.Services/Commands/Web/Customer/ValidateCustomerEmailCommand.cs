using System;
using System.Linq;
using System.Threading.Tasks;
using DevaxiloS.DataAccess.MsSql.EntityFramework;
using DevaxiloS.Infras.Commands;
using DevaxiloS.Infras.Common.Constants;
using DevaxiloS.Infras.Common.Enums;
using DevaxiloS.Infras.Common.Utils;
using DevaxiloS.Infras.Messaging;

namespace DevaxiloS.Services.Commands.Web.Customer
{
    public class ValidateCustomerEmailCommand : Command
    {
        public string Email { get; }

        public CommandResponse<bool> Response { get; set; }

        public ValidateCustomerEmailCommand(int id, string email) : base(id)
        {
            Email = email;
        }
    }

    public class ValidateCustomerEmailCommandHandler : ICommandHandler<ValidateCustomerEmailCommand>
    {
        public async Task Execute(ValidateCustomerEmailCommand command)
        {
            var dnow = DateTime.UtcNow;
            using (var context = new DevaxiloContext())
            {
                var user = context.Accounts.SingleOrDefault(x => x.Email == command.Email);
                if (user != null && user.Status == (byte) SysStatus.Deleted)
                {
                    command.Response = new CommandResponse<bool>(false, true, "Account is blocked");
                    return;
                }

                var userLogin = new AccountLogin {
                    ExpiredAt = dnow.AddMinutes(15),
                    HashLoginCode = CryptoUtils.Encrypt(dnow.ToString(StringConstants.DateTimeFormatUs), command.Email)
                };

                if (user == null)
                {
                    var customer = new Account
                    {
                        Email = command.Email,
                        Status = (byte) SysStatus.New,
                        CreatedAt = dnow,
                        EnableTransferAuthen = false,
                        UUID = Guid.NewGuid()
                    };

                    context.Accounts.Add(customer);
                    userLogin.AccId = customer.Id;
                }
                else
                {
                    userLogin.AccId = user.Id;
                }
                context.AccountLogin.Add(userLogin);
                await context.SaveChangesAsync();

                //TODO: send email

                command.Response = new CommandResponse<bool>(true, false, "Account is ok");
            }
        }
    }
}
