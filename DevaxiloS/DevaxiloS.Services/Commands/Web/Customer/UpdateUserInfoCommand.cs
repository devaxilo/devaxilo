using System.Threading.Tasks;
using DevaxiloS.DataAccess.MsSql.EntityFramework;
using DevaxiloS.Infras.Commands;
using DevaxiloS.Infras.Messaging;
using DevaxiloS.Services.DomainModels.Customer;

namespace DevaxiloS.Services.Commands.Web.Customer
{
    public class UpdateUserInfoCommand : Command
    {
        public UserInfoRequest Request { get; }

        public CommandResponse<bool> Response { get; set; }

        public UpdateUserInfoCommand(int id, UserInfoRequest request) : base(id)
        {
            Request = request;
        }
    }

    public class UpdateUserInfoCommandHandler: ICommandHandler<UpdateUserInfoCommand>
    {
        public async Task Execute(UpdateUserInfoCommand command)
        {
            var request = command.Request;
            using (var context = new DevaxiloContext())
            {
                var user = context.Accounts.Find(request.UserId);
                if (user != null)
                {
                    user.FullName = request.FullName;
                    user.Phone = request.Phone;
                    await context.SaveChangesAsync();
                    command.Response = new CommandResponse<bool>(true);
                }
            }
        }
    }
}
