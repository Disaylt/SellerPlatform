using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Abstraction.Interfaces;
using Core.Abstraction.Models;
using Core.Implementation.MongoDbDriver.Abstraction;
using Core.Implementation.MongoDbDriver.Implementation;
using Core.Implementation.MongoDbDriver.Models;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace Core.Implementation.MongoDbDriver
{
    public static class RegisterExtensions
    {
        public static IServiceCollection AddCoreMongoDb(
            this IServiceCollection serviceCollection,
            Action<MongoDatabaseOptions> setOptions)
        {
            MongoDatabaseOptions mongoDatabaseOptions = new();
            setOptions(mongoDatabaseOptions);

            serviceCollection.AddSingleton<IMongoClient>(new MongoClient(mongoDatabaseOptions.ConnectionSting));
            serviceCollection.AddSingleton(x =>
                x.GetRequiredService<IMongoClient>().GetDatabase(mongoDatabaseOptions.Database));
            serviceCollection.AddScoped<IMongoClientSessionManager, MongoClientSessionManager>();
            serviceCollection.AddScoped<ITransactionManager, MongoTransactionManager>();

            BsonClassMap.RegisterClassMap<BaseEntity>(cm =>
            {
                cm.AutoMap();
                cm.SetIsRootClass(true);
                cm.UnmapProperty(e => e.Notifications);
            });

            return serviceCollection;
        }

        public static IServiceCollection AddCoreMongoCollection<T>(
            this IServiceCollection serviceCollection,
            string name)
            where T : BaseEntity
        {
            serviceCollection.AddSingleton(x =>
                x.GetRequiredService<IMongoDatabase>()
                    .GetCollection<T>(name));

            return serviceCollection;
        }

        public static IServiceCollection AddCoreMongoCollection<T>(
            this IServiceCollection serviceCollection,
            string name,
            Action<BsonClassMap<T>> config)
            where T : BaseEntity
        {
            BsonClassMap.RegisterClassMap<T>(cm =>
            {
                cm.AutoMap();
                cm.SetDiscriminator(typeof(T).Name);

                config(cm);
            });

            return serviceCollection.AddCoreMongoCollection<T>(name);
        }
    }
}
