using Account.Users.Application.Features.Users.Models;
using Core.Application.Interfaces;
using MediatR;

namespace Account.Users.Application.Features.Users.Commands.Login;

public class LoginUserCommand : IRequest<AuthInfoDto>, ITransactionRequest
{
    public required string LoginOrEmail { get; set; }
    public required string Password { get; set; }
}
