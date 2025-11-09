using Account.Notifications.Application.Features.Notifications.Commands.Create;
using Account.Notifications.Application.Features.Notifications.Models;
using Account.Notifications.Application.Features.Notifications.Utilities.Abstraction;
using Account.Notifications.Domain.Entities;

namespace Account.Notifications.Application.Features.Notifications.Utilities.Implementation;

public class NotificationMapper : INotificationMapper
{
    public NotificationDto ToDto(Notification data)
    {
        return new NotificationDto
        {
            Id = data.Id,
            CorrelationId = data.CorrelationId,
            Created = data.Created,
            IsRead = data.IsRead,
            UserId = data.UserId,
            Message = data.Message
        };
    }

    public Notification ToEntity(CreateNotificationCommand data)
    {
        return new Notification
        {
            CorrelationId = data.CorrelationId,
            Message = data.Message,
            IsRead = data.IsRead,
            UserId = data.UserId
        };
    }
}