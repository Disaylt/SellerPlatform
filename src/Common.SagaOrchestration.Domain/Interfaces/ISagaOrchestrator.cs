namespace Common.SagaOrchestration.Domain.Interfaces;

public interface ISagaOrchestrator
{
    Task<string> RunAsync(object? data);
    Task NextStepAsync();
    
    string GetNextStep(string? stepName);
}
