using Core.Abstraction.Interfaces;
using Core.Implementation.EntityFramework.Outbox.Constants;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Core.Implementation.EntityFramework.Outbox.BackgroundServices;

internal class MessagesProducerBackgroundService(
    [FromKeyedServices(OutboxConstants.MesageBorkerProviderKey)] IEventBus eventBus)
    : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        throw new NotImplementedException();
    }
}
