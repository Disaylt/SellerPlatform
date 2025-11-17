using Common.SagaOrchestration.Domain.Entities;

namespace Common.SagaOrchestration.Domain.Interfaces;

public interface ISagaStep
{
    public Task ExecuteAsync(SagaContext context);
    public Task<bool> CompensateAsync(SagaContext context);
}
