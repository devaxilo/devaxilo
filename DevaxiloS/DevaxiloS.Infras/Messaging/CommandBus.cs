using System;
using System.Threading.Tasks;
using DevaxiloS.Infras.Commands;

namespace DevaxiloS.Infras.Messaging
{
    public class CommandResponse<TResponse>
{
        public TResponse ResponseObj { get; set; }
        public bool IsError { get; set; }
        public string Message { get; set; }

        public CommandResponse(TResponse resObj)
        {
            ResponseObj = resObj;
        }

        public CommandResponse(TResponse resObj, bool isError, string msg = null)
        {
            ResponseObj = resObj;
            IsError = isError;
            if(!string.IsNullOrWhiteSpace(msg)) Message = msg;
        }

    }

    public class CommandBus: ICommandBus
    {
        public async Task Send<TCommand>(TCommand command) where TCommand : Command
        {
            var handler = CommandHandlerFactory.CmdFactory.GetHandler<TCommand>();
            if (handler != null)
            {
                try
                {
                    await handler.Execute(command).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    throw new Exception("System Error");
                }
            }
            else
            {
                throw new ArgumentException("No handler registered");
            }
        }
    }
}
