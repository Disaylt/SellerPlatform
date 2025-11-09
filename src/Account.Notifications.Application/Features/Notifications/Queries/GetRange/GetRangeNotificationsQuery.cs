using Account.Notifications.Application.Features.Notifications.Models;
using Core.Abstraction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Account.Notifications.Application.Features.Notifications.Queries.GetRange;

public class GetRangeNotificationsQuery : IRequest<PaginationResponse<NotificationViewModel>>
{
    public NotificationFilterModel Filter { get; set; } = new();
    public PaginationRequest Pagination { get; set; } = new();
}
