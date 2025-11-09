using Grpc.Net.Client;

namespace Core.Implementation.GrpcClients.Abstraction;

internal interface IGrpcChannelsFactory
{
    T Create<T>(string address, GrpcChannelOptions? grpcChannelOptions = null) where T : class;
}
