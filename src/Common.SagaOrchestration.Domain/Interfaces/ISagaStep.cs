using Common.SagaOrchestration.Domain.Enums;

namespace Common.SagaOrchestration.Domain.Interfaces;

public interface ISagaStep
{
    string StepName { get; }
    Task<SagaStepStatus> ExecuteAsync(ISagaContext context);
    Task<bool> CompensateAsync(ISagaContext context);
}
