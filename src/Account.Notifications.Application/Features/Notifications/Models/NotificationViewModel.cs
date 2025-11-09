using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Notifications.Application.Features.Notifications.Models
{
    public record NotificationViewModel
    {
        public required string Id { get; init; }
        public string Message { get; init; } = string.Empty;
        public required DateTime Created { get; init; }
        public bool IsRead { get; init; }
    }
}
