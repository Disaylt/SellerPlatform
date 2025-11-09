using Common.SagaOrchestration.Domain.Interfaces;

namespace Common.SagaOrchestration.Application.Services.Abstraction;

public abstract class BaseSaga<TResult> where TResult : class
{
    protected readonly List<ISagaStep> Steps = [];
    protected readonly List<ISagaStep> ExecutedSteps = [];

    protected void AddStep(ISagaStep step)
    {
        Steps.Add(step);
    }

    protected abstract TResult BuildResult(ISagaContext context);
}
