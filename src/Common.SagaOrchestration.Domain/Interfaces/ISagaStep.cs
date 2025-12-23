using Common.SagaOrchestration.Domain.Entities;

namespace Common.SagaOrchestration.Domain.Interfaces;

public interface ISagaStep
{
    int AtteptsQuantity { get; }
    Task ExecuteAsync(SagaContext context);
    Task<bool> CompensateAsync(SagaContext context);
}
