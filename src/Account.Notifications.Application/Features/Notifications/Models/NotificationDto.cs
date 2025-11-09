namespace Account.Notifications.Application.Features.Notifications.Models;

public record NotificationDto
{
    public required string Id { get; init; }
    public required string UserId { get; init; }
    public string? CorrelationId { get; init; }
    public string Message { get; init; } = string.Empty;
    public required DateTime Created { get; init; }
    public bool IsRead { get; init; }
}