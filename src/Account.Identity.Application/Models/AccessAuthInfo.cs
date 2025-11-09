using Account.Identity.Domain.Seed;

namespace Account.Identity.Application.Models;

public record AccessAuthInfo : IAuthInfo
{
    public string Id { get; init; } = Guid.NewGuid().ToString();
    public required string SessionId { get; init; }
    public required string UserId { get; init; }
    public IEnumerable<string> Roles { get; init; } = [];
}
