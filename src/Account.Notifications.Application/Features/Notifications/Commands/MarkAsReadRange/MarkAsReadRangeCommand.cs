using Core.Application.Requests;
using MediatR;

namespace Account.Notifications.Application.Features.Notifications.Commands.MarkAsReadRange;

public class MarkAsReadRangeCommand : BaseCommand<Unit>
{
    public IEnumerable<string> Ids { get; set; } = [];
}