using Account.Identity.Application.Features.Sessions.Models;
using Core.Application.Requests;

namespace Account.Identity.Application.Features.Sessions.Commands.CreateAuthInfo;

public class CreateSessionAuthInfoCommand : BaseRequest<AuthDataDto>
{
    public required string UserId { get; set; }
    public IEnumerable<string> Roles { get; set; } = [];
}
