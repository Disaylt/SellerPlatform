using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Account.Identity.Application.Models;
using Account.Identity.Infrastructure.Services.Abstraction.Claims;
using Account.Identity.Infrastructure.Services.Abstraction.Tokens;
using Account.Identity.Infrastructure.Services.Implementation.Tokens;
using Microsoft.IdentityModel.Tokens;

namespace Account.Identity.Infrastructure.Services.Implementation.Claims;

public class JwtAccessClaimsService(IRolesClaimService rolesClaimService) : IClaimsService<AccessAuthInfo>
{
    public IEnumerable<Claim> Create(AccessAuthInfo details)
    {
        Claim jti = new(JwtRegisteredClaimNames.Jti, details.Id);
        Claim iat = new(JwtRegisteredClaimNames.Iat,
            EpochTime.GetIntDate(DateTime.UtcNow).ToString(CultureInfo.InvariantCulture),
            ClaimValueTypes.Integer64);
        Claim sessionId = new(ClaimTypes.Sid, details.SessionId);
        Claim userId = new(ClaimTypes.NameIdentifier, details.UserId);

        List<Claim> claims =
        [
            jti,
            iat,
            userId,
            sessionId
        ];


        IEnumerable<Claim> roles = rolesClaimService.Create(details.Roles);
        claims.AddRange(roles);

        return claims;
    }
}
