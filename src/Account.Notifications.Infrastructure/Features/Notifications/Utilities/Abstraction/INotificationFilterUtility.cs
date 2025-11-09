using Account.Notifications.Domain.Entities;
using Core.Abstraction.Models;
using MongoDB.Driver;

namespace Account.Notifications.Infrastructure.Features.Notifications.Utilities.Abstraction;

public interface INotificationFilterUtility
{
    INotificationFilterUtility UseUserId(string? userId);
    INotificationFilterUtility UseToDate(DateTime? toDate);
    INotificationFilterUtility UseFromDate(DateTime? fromDate);
    INotificationFilterUtility UseCorrelationId(string? nId);
    INotificationFilterUtility UseReadStatus(bool? isRead);
    FilterDefinition<Notification> Build();
}