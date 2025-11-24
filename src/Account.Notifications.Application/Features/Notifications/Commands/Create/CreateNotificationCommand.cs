using Account.Notifications.Application.Features.Notifications.Models;
using Core.Application.Requests;

namespace Account.Notifications.Application.Features.Notifications.Commands.Create;

public class CreateNotificationCommand : BaseCommand<NotificationDto>
{
    public required string UserId { get; set; }
    public string? CorrelationId { get; set; }
    public string Message { get; set; } = string.Empty;
    public bool IsRead { get; set; }
}