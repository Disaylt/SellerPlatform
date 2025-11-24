using Core.Abstraction.Interfaces;
using Core.Application.Requests;
using MediatR;

namespace Core.Application.Behaviors;

public class UnitOfWorkBehavior<TRequest, TResponse>(IUnitOfWork unitOfWork)
    : IPipelineBehavior<TRequest, TResponse> where TRequest : BaseCommand<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        TResponse response = await next(cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return response;
    }
}
