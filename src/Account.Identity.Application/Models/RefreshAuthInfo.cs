using Account.Identity.Domain.Seed;

namespace Account.Identity.Application.Models;

public class RefreshAuthInfo : IAuthInfo
{
    public required string SessionId { get; init; }
}
