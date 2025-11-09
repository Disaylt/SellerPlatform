namespace Common.SagaOrchestration.Domain.Interfaces;

public interface ISagaOrchestrator
{
    Task<TResult> ExecuteAsync<TResult>(ISagaContext context) where TResult : class;
    Task CompensateAsync(ISagaContext context);
}
