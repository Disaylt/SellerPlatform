using Core.Abstraction.Interfaces;
using Core.Implementation.EntityFramework.Abstraction;
using Core.Implementation.EntityFramework.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Implementation.EntityFramework;

public static class RegistrationServicesExtensions
{
    public static IServiceCollection AddEntityCreatedDomainEvent<TEntity>(this IServiceCollection serviceCollection) where TEntity : class
    {
        serviceCollection.AddSingleton<IDomainEventRecord, DomainCreatedEventRecord<TEntity>>();

        return serviceCollection;
    }

    public static IServiceCollection AddEntityDeletedDomainEvent<TEntity>(this IServiceCollection serviceCollection) where TEntity : class
    {
        serviceCollection.AddSingleton<IDomainEventRecord, DomainDeletedEventRecord<TEntity>>();

        return serviceCollection;
    }

    public static IServiceCollection AddCoreEntityFrameworkInplementation<TDbContext>(this IServiceCollection serviceCollection)
        where TDbContext : DbContext
    {
        serviceCollection.AddSingleton<IDomainEventsStore, DomainEventsStore>();
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork<TDbContext>>();
        serviceCollection.AddScoped<ITransactionManager, TransactionManager<TDbContext>>();

        return serviceCollection;
    }
}
