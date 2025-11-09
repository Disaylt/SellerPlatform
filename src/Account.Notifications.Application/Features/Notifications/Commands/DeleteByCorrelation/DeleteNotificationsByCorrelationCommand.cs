using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Notifications.Application.Features.Notifications.Commands.DeleteByCorrelation;

public class DeleteNotificationsByCorrelationCommand : IRequest<Unit>
{
    public required string CorrelationId { get; set; }
}
