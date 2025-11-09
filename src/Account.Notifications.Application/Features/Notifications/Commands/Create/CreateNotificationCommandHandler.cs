using Account.Notifications.Application.Features.Notifications.Models;
using Account.Notifications.Application.Features.Notifications.Utilities.Abstraction;
using Account.Notifications.Domain.Entities;
using Account.Notifications.Domain.Seed;
using MediatR;

namespace Account.Notifications.Application.Features.Notifications.Commands.Create;

public class CreateNotificationCommandHandler(
    INotificationMapper notificationMapper,
    IRepository<Notification> notificationsRepository)
    : IRequestHandler<CreateNotificationCommand, NotificationDto>
{
    public async Task<NotificationDto> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
    {
        var entity = notificationMapper.ToEntity(request);
        await notificationsRepository.InsertAsync(entity, cancellationToken);

        return notificationMapper.ToDto(entity);
    }
}