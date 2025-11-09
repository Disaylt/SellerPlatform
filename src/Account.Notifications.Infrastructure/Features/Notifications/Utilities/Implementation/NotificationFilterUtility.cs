using Account.Notifications.Domain.Entities;
using Account.Notifications.Infrastructure.Features.Notifications.Utilities.Abstraction;
using Core.Abstraction.Models;
using MongoDB.Driver;

namespace Account.Notifications.Infrastructure.Features.Notifications.Utilities.Implementation;

public class NotificationFilterUtility : INotificationFilterUtility
{
    private readonly List<FilterDefinition<Notification>> _filters = [];

    public INotificationFilterUtility UseUserId(string? userId)
    {
        if (userId is not null)
        {
            var filter = new FilterDefinitionBuilder<Notification>()
                .Eq(x => x.UserId, userId);
            _filters.Add(filter);
        }

        return this;
    }

    public INotificationFilterUtility UseToDate(DateTime? toDate)
    {
        if (toDate.HasValue)
        {
            var filter = new FilterDefinitionBuilder<Notification>()
                .Gte(x => x.Created, toDate.Value);
            _filters.Add(filter);
        }

        return this;
    }

    public INotificationFilterUtility UseFromDate(DateTime? fromDate)
    {
        if (fromDate.HasValue)
        {
            var filter = new FilterDefinitionBuilder<Notification>()
                .Gte(x => x.Created, fromDate.Value);
            _filters.Add(filter);
        }

        return this;
    }

    public INotificationFilterUtility UseCorrelationId(string? correlationId)
    {
        if (correlationId is not null)
        {
            var filter = new FilterDefinitionBuilder<Notification>()
                .Eq(x => x.UserId, correlationId);
            _filters.Add(filter);
        }

        return this;
    }

    public INotificationFilterUtility UseReadStatus(bool? isRead)
    {
        if (isRead.HasValue)
        {
            var filter = new FilterDefinitionBuilder<Notification>()
                .Eq(x => x.IsRead, isRead.Value);
            _filters.Add(filter);
        }

        return this;
    }

    public FilterDefinition<Notification> Build()
    {
        if (_filters.Count == 0)
        {
            return FilterDefinition<Notification>.Empty;
        }

        return new FilterDefinitionBuilder<Notification>().And(_filters);
    }
}