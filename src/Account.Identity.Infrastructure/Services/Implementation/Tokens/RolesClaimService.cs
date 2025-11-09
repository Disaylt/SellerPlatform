using System.Security.Claims;
using Account.Identity.Infrastructure.Services.Abstraction.Tokens;

namespace Account.Identity.Infrastructure.Services.Implementation.Tokens;

public class RolesClaimService : IRolesClaimService
{
    public virtual IEnumerable<Claim> Create(IEnumerable<string> roles)
    {
        return roles
            .Distinct()
            .Select(r => new Claim(ClaimTypes.Role, r));
    }
}
