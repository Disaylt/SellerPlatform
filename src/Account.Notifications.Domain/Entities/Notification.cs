using Account.Notifications.Domain.Seed;
using Core.Abstraction.Models;
namespace Account.Notifications.Domain.Entities
{
    public class Notification : BaseEntity, IEntityIdentifier
    {
        public string Id { get; set; } = null!;
        public required string UserId { get; set; }
        public required string Message { get; set; }
        public bool IsRead { get; set; }
    }
}
