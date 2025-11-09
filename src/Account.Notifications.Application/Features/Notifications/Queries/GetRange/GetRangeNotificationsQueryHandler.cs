using Account.Notifications.Application.Features.Notifications.DataQueries;
using Account.Notifications.Application.Features.Notifications.Models;
using Core.Abstraction.Interfaces;
using Core.Abstraction.Models;
using MediatR;

namespace Account.Notifications.Application.Features.Notifications.Queries.GetRange;

public class GetRangeNotificationsQueryHandler(
    IDataQueryHandler<GetRangeViewProjectionNotificationsDataQuery, IList<NotificationViewModel>> getRangeQueryDataHandler,
    IDataQueryHandler<CountNotificationsDataQuery, long> countQueryDataHandler)
    : IRequestHandler<GetRangeNotificationsQuery, PaginationResponse<NotificationViewModel>>
{
    public async Task<PaginationResponse<NotificationViewModel>> Handle(GetRangeNotificationsQuery request, CancellationToken cancellationToken)
    {
        GetRangeViewProjectionNotificationsDataQuery getRangeQueryData = new()
        {
            Filter = request.Filter,
            Pagination = request.Pagination
        };

        CountNotificationsDataQuery countQueryData = new()
        {
            Filter = request.Filter
        };

        return new PaginationResponse<NotificationViewModel>()
        {
            Items = await getRangeQueryDataHandler.ExecuteAsync(getRangeQueryData, cancellationToken),
            Total = await countQueryDataHandler.ExecuteAsync(countQueryData, cancellationToken)
        };
    }
}