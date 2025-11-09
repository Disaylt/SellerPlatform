using MongoDB.Driver;

namespace Core.Implementation.MongoDbDriver.Abstraction;

public interface IMongoClientSessionManager
{
    IClientSessionHandle SessionHandle { get; }
}