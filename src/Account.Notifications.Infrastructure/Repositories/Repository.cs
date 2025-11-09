using Account.Notifications.Domain.Entities;
using Account.Notifications.Domain.Seed;
using Core.Abstraction.Models;
using Core.Implementation.MongoDbDriver.Abstraction;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Account.Notifications.Infrastructure.Repositories;

public class Repository<T>(
    IMongoClientSessionManager mongoClientSessionManager,
    IMongoCollection<T> collection)
    : IRepository<T>
    where T : BaseEntity, IEntityIdentifier
{
    private readonly IClientSessionHandle _sessionHandle = mongoClientSessionManager.SessionHandle;
    protected IClientSessionHandle SessionHandle => _sessionHandle;
    protected IMongoCollection<T> Collection => collection;

    public async Task<T> FindAsync(string id, CancellationToken ct)
    {
        var filter = new FilterDefinitionBuilder<T>()
            .Where(x => x.Id == id);

        return await collection
            .Find(SessionHandle, filter)
            .SingleAsync(ct);
    }

    public async Task InsertAsync(T notification, CancellationToken ct)
    {
        await collection.InsertOneAsync(_sessionHandle, notification, null, ct);
    }

    public async Task DeleteManyAsync(Expression<Func<T, bool>> filter, CancellationToken ct)
    {
        await collection.DeleteManyAsync(filter, ct);
    }
}