using Core.Abstraction.Interfaces;
using Core.Implementation.EntityFramework.Outbox.Services.Abstract;
using Core.Implementation.EntityFramework.Outbox.Services.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Implementation.EntityFramework.Outbox;

public static class RegistrationServicesExtenstion
{
    public static IServiceCollection AddEntityFrameworkOutbox<TDbContext>(
        this IServiceCollection services, 
        Action<EntityFramefowrkOutboxOptions> optionsAction)
        where TDbContext : DbContext
    {
        var options = new EntityFramefowrkOutboxOptions(services);
        optionsAction(options);

        services.AddScoped<IOutboxRepository, OutboxRepository<TDbContext>>();
        services.AddScoped<IEventBus, OutboxEventBus>();

        return services;
    }
}
