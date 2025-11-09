using System.Security.Claims;

namespace Account.Identity.Infrastructure.Services.Abstraction.Tokens;

public interface IRolesClaimService
{
    IEnumerable<Claim> Create(IEnumerable<string> roles);
}
