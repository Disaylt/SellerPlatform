namespace Common.SagaOrchestration.Domain.Entities;

public class SagaStep
{
    public string Name { get; private set; } 
    public string? RequestData { get; set; }
    public string? ResponseData { get; set; }
    public int Attempts { get; set; }

    public string SagaId { get; set; } = null!;
    public SagaContext Saga { get; set; } = null!;

    public SagaStep()
    {
        Name = null!;
    }

    public SagaStep(string name)
    {
        Name = name;
    }
}
