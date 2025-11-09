using Account.Notifications.Application.Features.Notifications.Models;
using Account.Notifications.Domain.Entities;
using MongoDB.Driver;

namespace Account.Notifications.Infrastructure.Features.Notifications.Utilities.Abstraction;

public interface INotificationFilterFacade
{
    FilterDefinition<Notification> CreateFilter(NotificationFilterModel? filter);
}