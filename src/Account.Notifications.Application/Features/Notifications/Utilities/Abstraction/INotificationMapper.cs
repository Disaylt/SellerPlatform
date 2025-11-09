using Account.Notifications.Application.Features.Notifications.Commands.Create;
using Account.Notifications.Application.Features.Notifications.Models;
using Account.Notifications.Domain.Entities;

namespace Account.Notifications.Application.Features.Notifications.Utilities.Abstraction;

public interface INotificationMapper
{
    Notification ToEntity(CreateNotificationCommand data);
    NotificationDto ToDto(Notification data);
}