using Account.Notifications.Application.Features.Notifications.Models;
using Core.Abstraction.Models;
using Core.Application.Requests;

namespace Account.Notifications.Application.Features.Notifications.Queries.GetRange;

public class GetRangeNotificationsQuery : BaseQuery<PaginationResponse<NotificationViewModel>>
{
    public NotificationFilterModel Filter { get; set; } = new();
    public PaginationRequest Pagination { get; set; } = new();
}
