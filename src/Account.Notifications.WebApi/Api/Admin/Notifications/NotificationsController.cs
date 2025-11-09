using Account.Notifications.Application.Features.Notifications.Commands.Create;
using Account.Notifications.Application.Features.Notifications.Queries.GetRange;
using Account.Notifications.WebApi.Models.Admin.Notifications;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Account.Notifications.WebApi.Api.Admin.Notifications
{
    [Route("api/v{version:apiVersion}/admin/notifications")]
    [ApiController]
    [ApiVersion(1)]
    public class NotificationsController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        [MapToApiVersion(1)]
        public async Task<IActionResult> CreateV1Async([FromBody] CreateNotificationsModelV1 body, CancellationToken ct)
        {
            var commands = new CreateNotificationCommand
            {
                UserId = body.UserId,
                Message = body.Message
            };

            var result = await mediator.Send(commands, ct);

            return Ok(result);
        }

        [HttpGet]
        [MapToApiVersion(1)]
        public async Task<IActionResult> GetV1Async([FromQuery] GetNotificationsV1Model query, CancellationToken ct)
        {
            var request = new GetRangeNotificationsQuery
            {
                Filter = new()
                {
                    From = query.From,
                    To = query.To,
                    IsRead = query.IsRead,
                    CorrelationId = query.CorrelationId,
                    UserId = query.UserId
                },
                Pagination = new()
                {
                    Skip = query.Skip,
                    Take = query.Take
                }
            };

            var result = await mediator.Send(request, ct);

            return Ok(result);
        }
    }
}
