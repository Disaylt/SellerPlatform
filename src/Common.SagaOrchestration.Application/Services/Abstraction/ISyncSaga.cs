using Common.SagaOrchestration.Domain.Interfaces;

namespace Common.SagaOrchestration.Application.Services.Abstraction;

public interface ISyncSaga<TResult> where TResult : class
{
    Task<TResult> ExecuteAsync(ISagaContext context);
}
