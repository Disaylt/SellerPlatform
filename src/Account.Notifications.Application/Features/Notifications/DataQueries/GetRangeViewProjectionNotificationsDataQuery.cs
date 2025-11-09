using Account.Notifications.Application.Features.Notifications.Models;
using Core.Abstraction.Interfaces;
using Core.Abstraction.Models;

namespace Account.Notifications.Application.Features.Notifications.DataQueries;

public class GetRangeViewProjectionNotificationsDataQuery : IDataQuery<IList<NotificationViewModel>>
{
    public NotificationFilterModel? Filter { get; set; }
    public PaginationRequest? Pagination { get; set; }
}