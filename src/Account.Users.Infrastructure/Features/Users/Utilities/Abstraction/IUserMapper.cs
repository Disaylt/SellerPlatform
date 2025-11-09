using Account.Users.Domain.Entities;
using Account.Users.Infrastructure.Features.Users.Models;

namespace Account.Users.Infrastructure.Features.Users.Utilities.Abstraction
{
    public interface IUserMapper
    {
        AppIdentityUser ToIdentity(User user);
        User ToEntity(AppIdentityUser user);
    }
}
