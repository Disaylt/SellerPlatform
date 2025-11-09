using Account.Notifications.Domain.Seed;
using Core.Abstraction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
