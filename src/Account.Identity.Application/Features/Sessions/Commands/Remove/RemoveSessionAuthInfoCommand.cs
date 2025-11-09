using Core.Application.Requests;
using MediatR;

namespace Account.Identity.Application.Features.Sessions.Commands.Remove;

public class RemoveSessionAuthInfoCommand : BaseRequest<Unit>
{
    public required string UserId { get; set; }
}
