using Account.Notifications.Domain.Repositories;
using MediatR;

namespace Account.Notifications.Application.Features.Notifications.Commands.MarkAsReadRange;

public class MarkAsReadRangeCommandHandler(
    INotificationsRepository notificationsRepository)
    : IRequestHandler<MarkAsReadRangeCommand, Unit>
{
    public async Task<Unit> Handle(MarkAsReadRangeCommand request, CancellationToken cancellationToken)
    {
        await notificationsRepository.SetAsReadManyAsync(request.Ids, cancellationToken);

        return Unit.Value;
    }
}