namespace Common.SagaOrchestration.Domain.Interfaces;

public interface ISagaStepMachine
{
    string Name { get; }
    string FirstStep { get; }
    string? GetNextStep(string? stepName);
}
