using Core.Abstraction.Interfaces;
using Core.Implementation.EntityFramework.Outbox.Constants;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Implementation.EntityFramework.Outbox.Services.Implementation;

public class EntityFramefowrkOutboxOptions
{
    private readonly IServiceCollection _serviceCollection;

    internal bool ContainsMessageBrokerProvider { get; private set; }

    internal EntityFramefowrkOutboxOptions(IServiceCollection serviceCollection)
    {
        _serviceCollection = serviceCollection;
    }

    public void AddMessageBroker<T>() where T : class, IEventBus
    {
        _serviceCollection.AddKeyedSingleton<IEventBus, T>(OutboxConstants.MesageBorkerProviderKey);
        ContainsMessageBrokerProvider = true;
    }
}
