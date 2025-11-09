using Account.Users.Application.Features.Users.Helpers.Abstraction;
using Account.Users.Application.Features.Users.Models;
using Account.Users.Domain.Entities;

namespace Account.Users.Application.Features.Users.Helpers.Implementation;

public class UserMapper : IUserMapper
{
    public UserDto ToDto(User user)
    {
        return new()
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Created = user.Created
        };
    }
}
