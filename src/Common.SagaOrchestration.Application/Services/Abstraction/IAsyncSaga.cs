using Common.SagaOrchestration.Domain.Enums;
using Common.SagaOrchestration.Domain.Interfaces;

namespace Common.SagaOrchestration.Application.Services.Abstraction;

public interface IAsyncSaga<TResult> where TResult : class
{
    Task<string> StartAsync(ISagaContext context);
    Task<TResult?> GetResultAsync(string sagaId);
    Task<SagaStatus> GetStatusAsync(string sagaId);
}
