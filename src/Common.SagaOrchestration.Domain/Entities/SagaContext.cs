using Common.SagaOrchestration.Domain.Enums;
using Common.SagaOrchestration.Domain.Interfaces;

namespace Common.SagaOrchestration.Domain.Entities;

public class SagaContext : ISagaContext
{
    public string Id { get; } = Guid.NewGuid().ToString();
    public SagaStatus Status { get; set; } = SagaStatus.Pending;
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public int MaxAtempates { get; set; } = 10;

    public IList<SagaStep> Steps { get; set; } = [];
}
