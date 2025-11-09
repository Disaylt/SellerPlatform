using Account.Users.Application.Features.Users.Models;
using Core.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Users.Application.Features.Users.Commands.Register
{
    public class RegisterUserCommand : IRequest<AuthInfoDto>, ITransactionRequest
    {
        public required string Login { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
