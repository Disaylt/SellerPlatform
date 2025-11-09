namespace Core.Abstraction.Interfaces;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<int> SaveChangesAndEventsAsync(CancellationToken cancellationToken = default);
}