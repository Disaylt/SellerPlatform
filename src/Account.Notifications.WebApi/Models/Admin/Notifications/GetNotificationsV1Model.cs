using System.ComponentModel.DataAnnotations;

namespace Account.Notifications.WebApi.Models.Admin.Notifications
{
    public class GetNotificationsV1Model
    {
        public int Take { get; init; }
        public int Skip { get; init; }
        public string? UserId { get; init; }
        public string? CorrelationId { get; init; }
        public bool? IsRead { get; init; }
        public DateTime? From { get; init; }
        public DateTime? To { get; init; }
    }
}
