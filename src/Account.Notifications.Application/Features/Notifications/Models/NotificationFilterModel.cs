using Core.Abstraction.Models;

namespace Account.Notifications.Application.Features.Notifications.Models;

public class NotificationFilterModel
{
    public string? UserId { get; set; }
    public bool? IsRead { get; set; }
    public string? CorrelationId { get; set; }
    public DateTime? From { get; set; }
    public DateTime? To { get; set; }
}