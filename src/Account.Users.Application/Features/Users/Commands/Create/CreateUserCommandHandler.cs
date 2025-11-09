using Account.Users.Application.Features.Users.Helpers.Abstraction;
using Account.Users.Application.Features.Users.Models;
using Account.Users.Application.Features.Users.Services.Abstraction;
using MediatR;

namespace Account.Users.Application.Features.Users.Commands.Create;

public class CreateUserCommandHandler(
    IUserService userService,
    IUserMapper userMapper)
    : IRequestHandler<CreateUserCommand, UserDto>
{
    public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userService.CreateAsync(request.Login, request.Email, request.Password);

        return userMapper.ToDto(user);
    }
}
