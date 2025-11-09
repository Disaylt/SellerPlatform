using MediatR;

namespace Account.Users.Application.Features.Users.Commands.Delete;

public class DeleteUserCommand : IRequest<Unit>
{
    public required string Id { get; set; }
}
