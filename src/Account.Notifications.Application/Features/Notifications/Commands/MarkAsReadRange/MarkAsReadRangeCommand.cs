using Core.Abstraction.Interfaces;
using Core.Application.Interfaces;
using MediatR;

namespace Account.Notifications.Application.Features.Notifications.Commands.MarkAsReadRange;

public class MarkAsReadRangeCommand : IRequest<Unit>, ITransactionRequest
{
    public IEnumerable<string> Ids { get; set; } = [];
}