using Account.Users.Application.Features.Users.Services.Abstraction;
using MediatR;

namespace Account.Users.Application.Features.Users.Commands.Delete;

public class DeleteUserCommandHandler(
    IUserService userService)
    : IRequestHandler<DeleteUserCommand, Unit>
{
    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        await userService.DeleteAsync(request.Id);

        return Unit.Value;
    }
}
