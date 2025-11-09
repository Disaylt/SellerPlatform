using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Account.Identity.Application.Models;
using Account.Identity.Application.Services.Abstraction;
using Account.Identity.Infrastructure.Models.Common;
using Account.Identity.Infrastructure.Services.Abstraction.Claims;
using Account.Identity.Infrastructure.Services.Abstraction.Tokens;
using Account.Identity.Infrastructure.Services.Implementation.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Account.Identity.Infrastructure.Services.Implementation.Tokens
{
    public class JwtAccessTokenService(
        IClaimsService<AccessAuthInfo> claimsService,
        IJwtTokenService jwtTokenService,
        IOptions<IdentityInfrastructureOptions> identityInfrustructureOptions)
        : ITokenService<AccessAuthInfo>
    {
        private readonly IdentityInfrastructureOptions _indeityConfig = identityInfrustructureOptions.Value;

        public string Create(AccessAuthInfo value)
        {
            DateTime expires = DateTime.UtcNow.AddMinutes(_indeityConfig.ExpireAccessTokenSeconds);
            IEnumerable<Claim> claims = claimsService.Create(value);
            SigningCredentials signingCredentials = jwtTokenService.CreateSigningCredentials(_indeityConfig.AuthSecret);

            JwtSecurityToken jwtSecurityToken = new(
                _indeityConfig.ValidIssuer,
                _indeityConfig.ValidAudience,
                claims,
                expires: expires,
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);
        }

        public async Task<bool> IsValid(string token)
        {
            TokenValidationResult result = await jwtTokenService
                .GetValidationResultAsync(
                    token,
                    _indeityConfig.AuthSecret,
                    _indeityConfig.ValidAudience,
                    _indeityConfig.ValidIssuer,
                    checkValidateAudience: _indeityConfig.IsCheckValidAudience,
                    checkValidateIssuer: _indeityConfig.IsCheckValidIssuer);

            return result.IsValid;
        }

        public AccessAuthInfo Read(string token)
        {
            JwtSecurityToken jwtSecurityToken = jwtTokenService.ReadJwtToken(token);

            AccessAuthInfo jwtAccessTokenDto = new()
            {
                UserId = jwtSecurityToken.Claims.FindByType(ClaimTypes.NameIdentifier) ?? "",
                SessionId = jwtSecurityToken.Claims.FindByType(ClaimTypes.Sid) ?? "",
                Roles = ParseRoles(jwtSecurityToken.Claims),
                Id = jwtSecurityToken.Claims.FindByType(JwtRegisteredClaimNames.Jti) ?? ""
            };

            return jwtAccessTokenDto;
        }

        private static IEnumerable<string> ParseRoles(IEnumerable<Claim> claims)
        {
            return claims
                .Where(x => x.Type == ClaimTypes.Role)
                .Select(x => x.Value);
        }
    }
}
