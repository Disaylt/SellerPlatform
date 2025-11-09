using Account.Users.Domain.Entities;
using Account.Users.Infrastructure.Features.Users.Models;
using Account.Users.Infrastructure.Features.Users.Utilities.Abstraction;

namespace Account.Users.Infrastructure.Features.Users.Utilities.Implementation;

public class UserMapper : IUserMapper
{
    public AppIdentityUser ToIdentity(User user)
    {
        return new AppIdentityUser
        {
            Id = user.Id,
            UserName = user.Name,
            Email = user.Email,
            Created = user.Created,
        };
    }

    public User ToEntity(AppIdentityUser user)
    {
        return new User
        {
            Id = user.Id,
            Name = user.UserName ?? throw new NullReferenceException($"{nameof(AppIdentityUser.UserName)} is null."),
            Email = user.Email ?? throw new NullReferenceException($"{nameof(AppIdentityUser.Email)} is null."),
            Created = user.Created
        };
    }
}
