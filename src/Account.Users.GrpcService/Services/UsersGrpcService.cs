using Account.Users.Application.Features.Users.Commands.Create;
using Account.Users.Application.Features.Users.Commands.Delete;
using Core.Contracts.Grpc.Models.Account.Users;
using Core.Contracts.Grpc.Services.Account.Users;
using MediatR;

namespace Account.Users.GrpcService.Services;

public class UsersGrpcService(IMediator mediator) : IUserExternalService
{
    public async Task<CreateUserResponseV1> CreateV1Async(CreateUserRequestV1 request)
    {
        var command = new CreateUserCommand
        {
            Login = request.Login,
            Email = request.Email,
            Password = request.Password
        };

        var response = await mediator.Send(command);

        return new CreateUserResponseV1
        {
            Id = response.Id,
            Email = response.Email,
            Login = response.Name
        };
    }

    public async Task RemoveV1Async(RemoveUserRequestV1 request)
    {
        var command = new DeleteUserCommand
        {
            Id = request.Id
        };

        await mediator.Send(command);
    }
}
