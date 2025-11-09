using Account.Notifications.Application.Features.Notifications.DataQueries;
using Account.Notifications.Application.Features.Notifications.Models;
using Account.Notifications.Domain.Entities;
using Account.Notifications.Domain.Repositories;
using Account.Notifications.Domain.Seed;
using Account.Notifications.Infrastructure.Features.Notifications.DataQueryHandlers;
using Account.Notifications.Infrastructure.Features.Notifications.Repositories;
using Account.Notifications.Infrastructure.Features.Notifications.Utilities.Abstraction;
using Account.Notifications.Infrastructure.Features.Notifications.Utilities.Implementation;
using Account.Notifications.Infrastructure.Models.Common;
using Account.Notifications.Infrastructure.Repositories;
using Core.Abstraction.Interfaces;
using Core.Implementation.MongoDbDriver;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson;

namespace Account.Notifications.Infrastructure;

public static class RegisterExtensions
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection serviceCollection, 
        NotificationsInfrastructureOptions infrastructureOptions)
    {
        serviceCollection.AddCoreMongoDb(opt =>
        {
            opt.SetConnection(infrastructureOptions.MongoDb.ConnectionString);
            opt.SetDatabaseName(infrastructureOptions.MongoDb.DatabaseName);
        });

        serviceCollection.AddCoreMongoCollection<Notification>("notifications",
            config =>
            {
                config
                  .MapIdProperty(x => x.Id)
                  .SetIdGenerator(StringObjectIdGenerator.Instance)
                  .SetSerializer(new StringSerializer(BsonType.ObjectId));
            });

        serviceCollection.AddSingleton<INotificationFilterFacade, NotificationFilterFacade>();
        serviceCollection.AddSingleton<INotificationUtilitiesFactory>(s =>
        {
            return new NotificationUtilitiesFactory(
                () => new NotificationFilterUtility());
        });

        serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        serviceCollection.AddScoped<INotificationsRepository, NotificationsRepository>();
        serviceCollection.AddScoped<IDataQueryHandler<CountNotificationsDataQuery, long>, CountNotificationsDataQueryHandler>();
        serviceCollection.AddScoped<IDataQueryHandler<GetRangeViewProjectionNotificationsDataQuery, IList<NotificationViewModel>>, GetRangeViewProjectionNotificationsDataQueryHandler>();

        return serviceCollection;
    }
}