using Core.Abstraction.Models;
using MongoDB.Bson.Serialization;

namespace Core.Implementation.MongoDbDriver.Implementation;

public static class BaseBsonEntityMap
{
    public static BsonClassMap RegisterClassMap<TEntity>(
        params Action<BsonClassMap<TEntity>>[] configs)
        where TEntity : BaseEntity
    {
        return BsonClassMap.RegisterClassMap<TEntity>(cm =>
        {
            cm.AutoMap();
            cm.SetIgnoreExtraElements(true);
            cm.UnmapProperty(e => e.Notifications);

            foreach (var config in configs)
            {
                config(cm);
            }
        });
    }
}