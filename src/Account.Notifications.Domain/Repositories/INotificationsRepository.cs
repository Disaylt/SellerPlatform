using Account.Notifications.Domain.Entities;
using Account.Notifications.Domain.Seed;

namespace Account.Notifications.Domain.Repositories;

public interface INotificationsRepository : IRepository<Notification>
{
    Task SetAsReadManyAsync(IEnumerable<string> ids, CancellationToken ct);
}