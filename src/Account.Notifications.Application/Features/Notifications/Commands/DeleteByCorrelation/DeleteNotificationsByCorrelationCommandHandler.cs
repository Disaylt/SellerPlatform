using Account.Notifications.Domain.Entities;
using Account.Notifications.Domain.Seed;
using MediatR;

namespace Account.Notifications.Application.Features.Notifications.Commands.DeleteByCorrelation;

public class DeleteNotificationsByCorrelationCommandHandler(
    IRepository<Notification> notificationsRepository)
    : IRequestHandler<DeleteNotificationsByCorrelationCommand, Unit>
{
    public async Task<Unit> Handle(DeleteNotificationsByCorrelationCommand request, CancellationToken cancellationToken)
    {
        await notificationsRepository.DeleteManyAsync(x=> x.CorrelationId == request.CorrelationId, cancellationToken);

        return Unit.Value;
    }
}
