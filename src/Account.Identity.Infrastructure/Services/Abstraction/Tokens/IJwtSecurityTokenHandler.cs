using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Account.Identity.Infrastructure.Services.Abstraction.Tokens;

public interface IJwtSecurityTokenHandler
{
    JwtSecurityToken ReadJwtToken(string token);
    Task<TokenValidationResult> ValidateTokenAsync(string token, TokenValidationParameters validationParameters);
}
