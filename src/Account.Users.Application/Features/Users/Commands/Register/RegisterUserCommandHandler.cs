using Account.Users.Application.Features.Sessions.Services.Abstraction;
using Account.Users.Application.Features.Users.Models;
using Account.Users.Application.Features.Users.Services.Abstraction;
using Account.Users.Domain.Entities;
using Core.Contracts.Grpc.Models.Account.Identity;
using Core.Contracts.Grpc.Services.Account.Identity;
using MediatR;

namespace Account.Users.Application.Features.Users.Commands.Register
{
    public class RegisterUserCommandHandler(
        IIdentityExternalService identityExternalService,
        ISessionService sessionService,
        IUserService userService)
        : IRequestHandler<RegisterUserCommand, AuthInfoDto>
    {
        public async Task<AuthInfoDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = await userService.CreateAsync(request.Login, request.Email, request.Password);

            var session = new Session
            {
                Id = Guid.NewGuid().ToString(),
                UserId = user.Id,
                IsActive = true
            };

            await sessionService.CreateAsync(session, cancellationToken);

            var authInfoRequest = new NewAuthInfoRequestV1
            {
                UserId = user.Id,
                SessionId = session.Id
            };

            var authInfo = await identityExternalService.CreateAuthInfoV1(authInfoRequest);

            return new AuthInfoDto
            {
                AccessToken = authInfo.AccessToken,
                RefreshToken = authInfo.RefreshToken
            };
        }
    }
}
