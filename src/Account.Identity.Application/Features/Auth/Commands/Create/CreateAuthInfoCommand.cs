using Account.Identity.Application.Features.Auth.Models;
using Core.Application.Requests;

namespace Account.Identity.Application.Features.Auth.Commands.Create;

public class CreateAuthInfoCommand : BaseCommand<AuthDataDto>
{
    public required string UserId { get; set; }
    public required string SessionId { get; set; }
    public IEnumerable<string> Roles { get; set; } = [];
}
