using Core.Abstraction.Interfaces;
using Core.Implementation.MongoDbDriver.Abstraction;
using MongoDB.Driver;

namespace Core.Implementation.MongoDbDriver.Implementation;

internal class MongoTransactionManager(IMongoClientSessionManager mongoClientSessionManager)
    : ITransactionManager
{
    private readonly IClientSessionHandle _sessionHandle = mongoClientSessionManager.SessionHandle;
    public bool HasTransaction => _sessionHandle.IsInTransaction;

    public Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        _sessionHandle.StartTransaction();

        return Task.CompletedTask;
    }

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        await _sessionHandle.CommitTransactionAsync(cancellationToken);
    }

    public async Task RollbackAsync(CancellationToken cancellationToken = default)
    {
        await _sessionHandle.AbortTransactionAsync(cancellationToken);
    }
}