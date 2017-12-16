using System.Threading.Tasks;
using DevaxiloS.Infras.Commands;

namespace DevaxiloS.Infras.Messaging
{
    public interface ICommandBus
    {
        Task Send<TCommand>(TCommand command) where TCommand : Command;
    }
}
