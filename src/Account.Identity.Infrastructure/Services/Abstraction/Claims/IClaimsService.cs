using System.Security.Claims;
using Account.Identity.Domain.Seed;

namespace Account.Identity.Infrastructure.Services.Abstraction.Claims;

public interface IClaimsService<in T> where T : IAuthInfo
{
    IEnumerable<Claim> Create(T details);
}
