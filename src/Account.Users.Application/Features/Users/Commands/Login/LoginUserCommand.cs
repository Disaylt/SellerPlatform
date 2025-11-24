using Account.Users.Application.Features.Users.Models;
using Core.Application.Interfaces;
using Core.Application.Requests;
using MediatR;

namespace Account.Users.Application.Features.Users.Commands.Login;

public class LoginUserCommand : BaseCommand<AuthInfoDto>
{
    public required string LoginOrEmail { get; set; }
    public required string Password { get; set; }
}
