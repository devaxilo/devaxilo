using System;
using System.Collections.Concurrent;
using DevaxiloS.Infras.Common.Constants;

namespace DevaxiloS.Infras.Commands
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler<TCommand> GetHandler<TCommand>() where TCommand : Command;
    }

    public class CommandHandlerFactory : ICommandHandlerFactory
    {
        private readonly ConcurrentDictionary<string, object> _cmds = new ConcurrentDictionary<string, object>();
        private static readonly Lazy<CommandHandlerFactory> Factory = new Lazy<CommandHandlerFactory>(() => new CommandHandlerFactory());
        public static CommandHandlerFactory CmdFactory => Factory.Value;

        private CommandHandlerFactory()
        {

        }

        public ICommandHandler<TCommand> GetHandler<TCommand>() where TCommand : Command
        {
            var type = typeof(TCommand);
            var qualifiedName = type.AssemblyQualifiedName;
            var name = type.Name;
            var handler = qualifiedName.Replace(name, $"{name}{StringConstants.HandlerClassPostFix}");
            if (_cmds.ContainsKey(handler))
            {
                return (ICommandHandler<TCommand>) _cmds[handler];
            }

            var handlerType = Type.GetType(handler);
            var cmd = Activator.CreateInstance(handlerType);
            _cmds.TryAdd(handler, cmd);
            return (ICommandHandler<TCommand>) cmd;
        }

        
    }
}
