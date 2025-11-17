namespace Common.SagaOrchestration.Domain.Interfaces;

public interface IResultSagaOrchestrator
{
    string? GetNextStep(string? stepName);
}
