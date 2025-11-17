namespace Common.SagaOrchestration.Domain.Enums;
public enum SagaStatus
{
    Pending,
    InCompleteProgress,
    ImCompensatedProgress,
    Completed,
    Failed,
    Compensated
}
