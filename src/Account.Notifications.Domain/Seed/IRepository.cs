using Core.Abstraction.Models;
using System.Linq.Expressions;

namespace Account.Notifications.Domain.Seed;

public interface IRepository<T> where T : BaseEntity, IEntityIdentifier
{
    Task InsertAsync(T notification, CancellationToken ct);
    Task<T> FindAsync(string id, CancellationToken ct);
    Task DeleteManyAsync(Expression<Func<T, bool>> filter, CancellationToken ct);
}