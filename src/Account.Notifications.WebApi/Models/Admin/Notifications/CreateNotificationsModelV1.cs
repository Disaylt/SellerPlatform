namespace Account.Notifications.WebApi.Models.Admin.Notifications
{
    public record CreateNotificationsModelV1
    {
        public required string UserId { get; init; }
        public string Message { get; init; } = string.Empty;
    }
}
