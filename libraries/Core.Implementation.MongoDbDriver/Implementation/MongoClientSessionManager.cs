using Core.Implementation.MongoDbDriver.Abstraction;
using MongoDB.Driver;

namespace Core.Implementation.MongoDbDriver.Implementation;

internal class MongoClientSessionManager(IMongoClient mongoClient)
    : IMongoClientSessionManager, IDisposable
{
    public IClientSessionHandle SessionHandle { get; } = mongoClient.StartSession();

    public void Dispose()
    {
        SessionHandle.Dispose();
        GC.SuppressFinalize(this);
    }
}