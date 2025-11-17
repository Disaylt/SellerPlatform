using Common.SagaOrchestration.Domain.Interfaces;

namespace Common.SagaOrchestration.Application.Services.Abstraction;

public abstract class SagaStateMachine : ISagaStepMachine
{
    public string Name => throw new NotImplementedException();

    public string FirstStep => throw new NotImplementedException();

    protected abstract Dictionary<string, string> Steps { get; }

    public string? GetNextStep(string? stepName)
    {
        if(Steps.Count == 0) return null;

        if(stepName is null) return Steps.First().Value;

        return Steps.GetValueOrDefault(stepName);
    }
}
