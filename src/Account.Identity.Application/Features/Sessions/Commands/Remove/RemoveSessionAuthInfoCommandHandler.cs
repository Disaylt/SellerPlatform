using Account.Identity.Domain.Repositories;
using MediatR;

namespace Account.Identity.Application.Features.Sessions.Commands.Remove;

public class RemoveSessionAuthInfoCommandHandler(
    ISessionRepository sessionRepository)
    : IRequestHandler<RemoveSessionAuthInfoCommand, Unit>
{
    public async Task<Unit> Handle(RemoveSessionAuthInfoCommand request, CancellationToken cancellationToken)
    {
        var session = await sessionRepository.FindAsync(request.UserId);
        await sessionRepository.DeleteAsync(session, cancellationToken);

        return Unit.Value;
    }
}
