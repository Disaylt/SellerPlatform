using Account.Users.Application.Features.Users.Models;
using Account.Users.Domain.Entities;

namespace Account.Users.Application.Features.Users.Helpers.Abstraction;

public interface IUserMapper
{
    UserDto ToDto(User user);
}
