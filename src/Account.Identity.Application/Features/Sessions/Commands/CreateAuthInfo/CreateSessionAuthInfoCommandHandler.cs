using Account.Identity.Application.Features.Sessions.Models;
using Account.Identity.Application.Models;
using Account.Identity.Application.Services.Abstraction;
using Account.Identity.Domain.Entities;
using Account.Identity.Domain.Repositories;
using Core.Abstraction.Interfaces;
using Core.Application.Interfaces;
using MediatR;

namespace Account.Identity.Application.Features.Sessions.Commands.CreateAuthInfo;

public class CreateSessionAuthInfoCommandHandler(
    ISessionRepository sessionRepository,
    ITokenService<AccessAuthInfo> accessTokenService,
    ITokenService<RefreshAuthInfo> refreshTokenService,
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreateSessionAuthInfoCommand, AuthDataDto>, ITransactionRequest
{
    public async Task<AuthDataDto> Handle(CreateSessionAuthInfoCommand request, CancellationToken cancellationToken)
    {
        var session = new Session
        {
            Id = Guid.NewGuid().ToString(),
            CorrelationId = request.CorrelationId,
            IsActive = true,
            UserId = request.UserId
        };

        await sessionRepository.AddAsync(session, cancellationToken);

        var refreshAuthInfo = new RefreshAuthInfo { SessionId = session.Id };
        var refreshToken = refreshTokenService.Create(refreshAuthInfo);

        var accessAuthInfo = new AccessAuthInfo
        {
            SessionId = session.Id,
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
