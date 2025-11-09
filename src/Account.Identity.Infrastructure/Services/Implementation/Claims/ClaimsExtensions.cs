using System.Security.Claims;

namespace Account.Identity.Infrastructure.Services.Implementation.Claims;

public static class ClaimsExtensions
{
    public static string? FindByType(this IEnumerable<Claim> claims, string type)
    {
        return claims.FirstOrDefault(x => x.Type == type)?.Value;
    }
}
