using System.ComponentModel.DataAnnotations;

namespace Account.Notifications.WebApi.Models.Notifications
{
    public record GetNotificationsV1Model
    {
        [Range(0,100, ErrorMessage = "Диапазон от 0 до 100 записей.")]
        public int Take { get; init; }
        public int Skip { get; init; }
        public bool? IsRead { get; init; }
        public bool MarkAsRead { get; init; }
        public DateTime? From { get; init; }
        public DateTime? To { get; init; }
    }
}
