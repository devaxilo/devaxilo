using System.Threading.Tasks;
using DevaxiloS.Infras.Commands;
using DevaxiloS.Infras.Messaging;
using DevaxiloS.Services.DomainModels.Customer;

namespace DevaxiloS.Services.Commands.Web.Customer
{
    public class SaveCustomerCommand : Command
    {
        public CustomerRequest Customer { get; set; }

        //CommandResponse<T> : T can be any types
        public CommandResponse<CustomerResponse> Response { get; set; }

        public SaveCustomerCommand(int id, CustomerRequest customer) : base(id)
        {
            Customer = customer;
        }
    }

    public class SaveCustomerCommandHandler : ICommandHandler<SaveCustomerCommand>
    {
        public async Task Execute(SaveCustomerCommand command)
        {
            //do login here
            //....
            //command response:
            command.Response = new CommandResponse<CustomerResponse>(new CustomerResponse());
        }
    }
}
