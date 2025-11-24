using Account.Identity.Application.Features.Auth.Models;
using Account.Identity.Application.Models;
using Account.Identity.Application.Services.Abstraction;
using Core.Abstraction.Interfaces;
using Core.Application.Interfaces;
using MediatR;

namespace Account.Identity.Application.Features.Auth.Commands.Create;

public class CreateAuthInfoCommandHandler(
    ITokenService<AccessAuthInfo> accessTokenService,
    ITokenService<RefreshAuthInfo> refreshTokenService,
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreateAuthInfoCommand, AuthDataDto>, ITransactionRequest
{
    public async Task<AuthDataDto> Handle(CreateAuthInfoCommand request, CancellationToken cancellationToken)
    {
        var refreshAuthInfo = new RefreshAuthInfo { SessionId = request.SessionId };
        var refreshToken = refreshTokenService.Create(refreshAuthInfo);

        var accessAuthInfo = new AccessAuthInfo
        {
            UserId = request.UserId,
            Roles = request.Roles
        };
        var accessToken = accessTokenService.Create(accessAuthInfo);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new AuthDataDto
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }
}
