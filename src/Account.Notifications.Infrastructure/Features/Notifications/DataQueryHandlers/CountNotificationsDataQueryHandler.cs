using Account.Notifications.Application.Features.Notifications.DataQueries;
using Account.Notifications.Domain.Entities;
using Account.Notifications.Infrastructure.Features.Notifications.Utilities.Abstraction;
using Core.Abstraction.Interfaces;
using MongoDB.Driver;

namespace Account.Notifications.Infrastructure.Features.Notifications.DataQueryHandlers;

public class CountNotificationsDataQueryHandler(
    IMongoCollection<Notification> notificationCollection,
    INotificationFilterFacade notificationFilterFacade)
    : IDataQueryHandler<CountNotificationsDataQuery, long>
{
    public async Task<long> ExecuteAsync(CountNotificationsDataQuery queryData, CancellationToken ct)
    {
        FilterDefinition<Notification> filter = notificationFilterFacade.CreateFilter(queryData.Filter);

        return await notificationCollection
            .Find(filter)
            .CountDocumentsAsync(ct);
    }
}