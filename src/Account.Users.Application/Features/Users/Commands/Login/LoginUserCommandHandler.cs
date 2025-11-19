using System.Net;
using Account.Users.Application.Features.Sessions.Services.Abstraction;
using Account.Users.Application.Features.Users.Models;
using Account.Users.Application.Features.Users.Services.Abstraction;
using Core.Abstraction.Exceptions;
using Core.Contracts.Grpc.Services.Account.Identity;
using MediatR;

namespace Account.Users.Application.Features.Users.Commands.Login;

public class LoginUserCommandHandler(
        IIdentityExternalService identityExternalService,
        ISessionService sessionService,
        IUserService userService)
    : IRequestHandler<LoginUserCommand, AuthInfoDto>
{
    public async Task<AuthInfoDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        if(await userService.VerifyPassword(request.LoginOrEmail, request.Password) is false)
        {
            throw new CoreRequestException()
                .SetStatusCode(HttpStatusCode.Unauthorized)
                .AddMessages("Неверный пользователь или пароль.");
        }

        return new AuthInfoDto { AccessToken = "", RefreshToken = "" };
    }
}
