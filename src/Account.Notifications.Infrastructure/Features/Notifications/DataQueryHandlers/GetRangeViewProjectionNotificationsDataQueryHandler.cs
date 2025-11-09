using Account.Notifications.Application.Features.Notifications.DataQueries;
using Account.Notifications.Application.Features.Notifications.Models;
using Account.Notifications.Domain.Entities;
using Account.Notifications.Infrastructure.Features.Notifications.Utilities.Abstraction;
using Core.Abstraction.Interfaces;
using MongoDB.Driver;

namespace Account.Notifications.Infrastructure.Features.Notifications.DataQueryHandlers;

public class GetRangeViewProjectionNotificationsDataQueryHandler(
    IMongoCollection<Notification> notificationCollection,
    INotificationFilterFacade notificationFilterFacade)
: IDataQueryHandler<GetRangeViewProjectionNotificationsDataQuery, IList<NotificationViewModel>>
{
    public async Task<IList<NotificationViewModel>> ExecuteAsync(GetRangeViewProjectionNotificationsDataQuery queryData, CancellationToken ct)
    {
        FilterDefinition<Notification> filter = notificationFilterFacade.CreateFilter(queryData.Filter);

        return await notificationCollection
            .Find(filter)
            .SortByDescending(x => x.Created)
            .Skip(queryData.Pagination?.Skip)
            .Limit(queryData.Pagination?.Take)
            .Project(Builders<Notification>.Projection
                .Expression(d => new NotificationViewModel
                {
                    Created = d.Created,
                    Id = d.Id,
                    IsRead = d.IsRead,
                    Message = d.Message
                }))
            .ToListAsync(ct);
    }
}