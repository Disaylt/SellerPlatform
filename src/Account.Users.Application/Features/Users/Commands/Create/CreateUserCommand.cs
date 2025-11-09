using Account.Users.Application.Features.Users.Models;
using Core.Application.Interfaces;
using MediatR;

namespace Account.Users.Application.Features.Users.Commands.Create;

public class CreateUserCommand : IRequest<UserDto>, ITransactionRequest
{
    public required string Login { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}
