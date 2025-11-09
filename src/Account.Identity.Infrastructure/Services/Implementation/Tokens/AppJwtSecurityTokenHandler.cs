using System.IdentityModel.Tokens.Jwt;
using Account.Identity.Infrastructure.Services.Abstraction.Tokens;

namespace Account.Identity.Infrastructure.Services.Implementation.Tokens;

public class AppJwtSecurityTokenHandler : JwtSecurityTokenHandler, IJwtSecurityTokenHandler
{
}
