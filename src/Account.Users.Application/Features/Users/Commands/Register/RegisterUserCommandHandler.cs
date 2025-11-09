using Account.Users.Application.Features.Users.Models;
using MediatR;

namespace Account.Users.Application.Features.Users.Commands.Register
{
    public class RegisterUserCommandHandler()
        : IRequestHandler<RegisterUserCommand, AuthInfoDto>
    {
        public Task<AuthInfoDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
