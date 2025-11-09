using Account.Notifications.Application.Features.Notifications.Commands.Create;
using Account.Notifications.Application.Features.Notifications.Commands.MarkAsReadRange;
using Account.Notifications.Application.Features.Notifications.Models;
using Account.Notifications.Application.Features.Notifications.Queries.GetRange;
using Account.Notifications.WebApi.Models.Notifications;
using Asp.Versioning;
using Core.Abstraction.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Account.Notifications.WebApi.Api.Notifications;

[Route("api/v{version:apiVersion}/notifications")]
[ApiController]
[ApiVersion(1)]
public class NotificationsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [MapToApiVersion(1)]
    public async Task<IActionResult> GetAsync(
        [FromQuery] GetNotificationsV1Model query,
        CancellationToken ct)
    {
        var request = new GetRangeNotificationsQuery
        {
            Filter = new()
            {
                From = query.From,
                To = query.To,
                IsRead = query.IsRead
            },
            Pagination = new()
            {
                Skip = query.Skip,
                Take = query.Take
            }
        };

        var result = await mediator.Send(request, ct);

        if (query.MarkAsRead)
        {
            var markAsReadRequest = new MarkAsReadRangeCommand
            {
                Ids = result.Items.Select(i => i.Id)
            };

            await mediator.Send(markAsReadRequest, ct);
        }

        return Ok(result);
    }
}
