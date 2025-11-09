using Account.Notifications.Application.Features.Notifications.Models;
using Account.Notifications.Domain.Entities;
using Account.Notifications.Infrastructure.Features.Notifications.Utilities.Abstraction;
using MongoDB.Driver;

namespace Account.Notifications.Infrastructure.Features.Notifications.Utilities.Implementation;

public class NotificationFilterFacade(INotificationUtilitiesFactory notificationUtilitiesStore)
    : INotificationFilterFacade
{
    public FilterDefinition<Notification> CreateFilter(NotificationFilterModel? filter)
    {
        if (filter is null) return FilterDefinition<Notification>.Empty;

        return notificationUtilitiesStore
            .CreateFilterUtility()
            .UseCorrelationId(filter.CorrelationId)
            .UseReadStatus(filter.IsRead)
            .UseUserId(filter.UserId)
            .UseFromDate(filter.From)
            .UseToDate(filter.To)
            .Build();
    }
}