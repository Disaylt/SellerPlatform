using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using Account.Identity.Infrastructure.Services.Abstraction.Tokens;
using Core.Abstraction.Exceptions;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Account.Identity.Infrastructure.Services.Implementation.Tokens;

public class JwtTokenService(
    IJwtSecurityTokenHandler jwtSecurityTokenHandler,
    ILogger<JwtTokenService> logger)
    : IJwtTokenService
{

    public virtual SigningCredentials CreateSigningCredentials(string secret)
    {
        byte[] secretBytes = Encoding.UTF8.GetBytes(secret);
        SymmetricSecurityKey authSigningKey = new(secretBytes);

        return new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256);
    }

    public virtual JwtSecurityToken ReadJwtToken(string token)
    {
        try
        {
            return jwtSecurityTokenHandler.ReadJwtToken(token);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unable to read jwt token - {token}", token);

            throw new CoreRequestException()
                .AddMessages("Не удалось прочить токен");
        }
    }

    public virtual async Task<TokenValidationResult> GetValidationResultAsync
        (string token,
            string secret,
            string? validAudience,
            string? validIssuer,
            bool checkIssuerSigningKey = true,
            bool checkValidateIssuer = true,
            bool checkValidateAudience = true,
            bool checkValidateLifetime = true)
    {
        HMACSHA256 hmac = new(Encoding.UTF8.GetBytes(secret));

        TokenValidationParameters tokenValidationParameters = new()
        {
            ValidateIssuerSigningKey = checkIssuerSigningKey,
            IssuerSigningKey = new SymmetricSecurityKey(hmac.Key),
            ValidateIssuer = checkValidateIssuer,
            ValidateAudience = checkValidateAudience,
            ValidateLifetime = checkValidateLifetime,
            ValidAudience = validAudience,
            ValidIssuer = validIssuer,
            ClockSkew = TimeSpan.Zero,
        };
        return await jwtSecurityTokenHandler.ValidateTokenAsync(token, tokenValidationParameters);
    }
}
