using Account.Identity.Application.Models;
using Account.Identity.Infrastructure.Services.Abstraction.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Account.Identity.Infrastructure.Services.Implementation.Claims;

public class JwtRefreshClaimsService : IClaimsService<RefreshAuthInfo>
{
    public IEnumerable<Claim> Create(RefreshAuthInfo details)
    {
        Claim jti = new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString());
        Claim iat = new(JwtRegisteredClaimNames.Iat,
            EpochTime.GetIntDate(DateTime.UtcNow).ToString(CultureInfo.InvariantCulture),
            ClaimValueTypes.Integer64);
        Claim sessionId = new(ClaimTypes.Sid, details.SessionId);

        List<Claim> claims =
        [
            jti,
                iat,
                sessionId
        ];

        return claims;
    }
}
