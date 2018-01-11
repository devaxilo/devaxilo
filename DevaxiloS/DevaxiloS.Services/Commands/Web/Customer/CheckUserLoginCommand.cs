using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DevaxiloS.DataAccess.MsSql.EntityFramework;
using DevaxiloS.Infras.Commands;
using DevaxiloS.Infras.Common.Enums;
using DevaxiloS.Infras.Messaging;
using DevaxiloS.Services.DomainModels.Customer;

namespace DevaxiloS.Services.Commands.Web.Customer
{
    public class CheckUserLoginCommand : Command
    {
        public string Email { get; }

        public CommandResponse<UserLoginResponse> Response { get; set; }

        public CheckUserLoginCommand(int id, string email) : base(id)
        {
            Email = email;
        }
    }

    public class CheckUserLoginCommandHandler : ICommandHandler<CheckUserLoginCommand>
    {
        public async Task Execute(CheckUserLoginCommand command)
        {
            using (var context = new DevaxiloContext())
            {
                var user = await context.Accounts.FirstOrDefaultAsync(x => x.Email.Equals(command.Email));
                if (user == null)
                {
                    command.Response = new CommandResponse<UserLoginResponse>(null);
                    return;
                }

                var userResponse = new UserLoginResponse
                {
                    Id = user.Id,
                    Email = command.Email,
                    UserStatus = (SysStatus)user.Status,
                    PasswordHash = user.HashPassword,
                    UserId = user.UUID,
                };

                command.Response = new CommandResponse<UserLoginResponse>(userResponse);
            }
        }
    }
}
