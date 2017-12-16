using System;
using System.Collections.Concurrent;
using System.Threading;
using DevaxiloS.Infras.Messaging;

namespace DevaxiloS.Services.Configuration
{
    public sealed class ServiceLocator
    {
        private readonly ConcurrentDictionary<string, object> _services = new ConcurrentDictionary<string, object>();
        private static readonly Lazy<ServiceLocator> Manager = new Lazy<ServiceLocator>(() => new ServiceLocator());

        public static ServiceLocator Services => Manager.Value;

        private ServiceLocator()
        {

        }

        private T GetService<T>()
        {
            var type = typeof(T).FullName;
            if (_services.ContainsKey(type))
            {
                return (T)_services[type];
            }

            var service = new Lazy<T>(LazyThreadSafetyMode.PublicationOnly);
            _services.TryAdd(type, service.Value);
            return service.Value;
        }

        private ICommandBus _commandBus;
        public ICommandBus CommandBus => _commandBus ?? (_commandBus = GetService<CommandBus>());
    }
}
