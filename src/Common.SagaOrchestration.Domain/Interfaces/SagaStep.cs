using Common.SagaOrchestration.Domain.Entities;
using Common.SagaOrchestration.Domain.Enums;

namespace Common.SagaOrchestration.Domain.Interfaces;

public abstract class SagaStep<TStep> : ISagaStep
{
    public static string Name => typeof(TStep).FullName ?? typeof(TStep).Name;

    public abstract Task ExecuteAsync(SagaContext context);
    public abstract Task<bool> CompensateAsync(SagaContext context);
}
