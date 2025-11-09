namespace Common.SagaOrchestration.Domain.Entities;

public class SagaStep
{
    public string Id { get; private set; } = Guid.NewGuid().ToString();
    public int Atemept { get; set; }
    public string? RequestData { get; set; }
    public string? ResponseData { get; set; }

    public string SagaId { get; set; } = null!;
    public SagaContext Saga { get; set; } = null!;
}
