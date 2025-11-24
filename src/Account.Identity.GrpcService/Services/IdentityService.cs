using Account.Identity.Application.Features.Auth.Commands.Create;
using Core.Contracts.Grpc.Models.Account.Identity;
using Core.Contracts.Grpc.Services.Account.Identity;
using MediatR;

namespace Account.Identity.GrpcService.Services;

public class IdentityService(IMediator mediator) : IIdentityExternalService
{
    public async Task<AuthInfoResponseV1> CreateAuthInfoV1(NewAuthInfoRequestV1 request)
    {
        var command = new CreateAuthInfoCommand
        {
            CorrelationId = request.CorrelationId,
            UserId = request.UserId,
            Roles = request.Roles,
            SessionId = request.SessionId
        };

        var result =  await mediator.Send(command);

        return new AuthInfoResponseV1
        {
            AccessToken = result.AccessToken,
            RefreshToken = result.RefreshToken
        };
    }
}
