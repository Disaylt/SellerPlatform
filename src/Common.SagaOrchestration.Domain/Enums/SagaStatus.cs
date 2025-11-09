namespace Common.SagaOrchestration.Domain.Enums;
public enum SagaStatus
{
    Pending,
    InProgress,
    Completed,
    Failed,
    Compensated
}
