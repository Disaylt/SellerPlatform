using Account.Notifications.Domain.Entities;
using Account.Notifications.Domain.Repositories;
using Account.Notifications.Infrastructure.Repositories;
using Core.Implementation.MongoDbDriver.Abstraction;
using MongoDB.Driver;

namespace Account.Notifications.Infrastructure.Features.Notifications.Repositories;

public class NotificationsRepository(
    IMongoClientSessionManager mongoClientSessionManager,
    IMongoCollection<Notification> notificationCollection)
    : Repository<Notification>(mongoClientSessionManager, notificationCollection), INotificationsRepository
{
    public async Task SetAsReadManyAsync(IEnumerable<string> ids, CancellationToken ct)
    {
        var filter = new FilterDefinitionBuilder<Notification>()
            .Where(x => ids.Contains(x.Id));

        var update = new UpdateDefinitionBuilder<Notification>()
            .Set(x => x.IsRead, true)
            .Set(x => x.Updated, DateTimeOffset.UtcNow);

        await Collection.UpdateManyAsync(SessionHandle, filter, update, null, ct);
    }
}