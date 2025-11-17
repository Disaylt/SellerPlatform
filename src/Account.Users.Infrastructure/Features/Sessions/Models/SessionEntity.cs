using Account.Users.Infrastructure.Features.Users.Models;
using Core.Abstraction.Models;

namespace Account.Users.Infrastructure.Features.Sessions.Models;

public class SessionEntity : BaseEntity
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public AppIdentityUser User { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public DateTime LastUse { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; }
}
