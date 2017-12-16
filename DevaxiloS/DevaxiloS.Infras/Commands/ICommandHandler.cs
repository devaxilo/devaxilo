using System.Threading.Tasks;

namespace DevaxiloS.Infras.Commands
{

    public interface ICommandHandler<in TCommand> where TCommand : Command
    {
        Task Execute(TCommand command);
    }
}
