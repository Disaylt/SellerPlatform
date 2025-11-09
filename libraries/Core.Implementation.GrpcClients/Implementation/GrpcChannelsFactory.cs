using Core.Implementation.GrpcClients.Abstraction;
using Core.Implementation.GrpcClients.Seed;
using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;

namespace Core.Implementation.GrpcClients.Implementation;

internal class GrpcChannelsFactory(IHttpClientFactory httpClientFactory) : IDisposable, IGrpcChannelsFactory
{
    private IList<GrpcChannel> _channels = [];

    public T Create<T>(string address, GrpcChannelOptions? grpcChannelOptions = null) where T : class
    {
        var options = grpcChannelOptions ?? new GrpcChannelOptions
        {
            DisposeHttpClient = false,
            HttpClient = httpClientFactory.CreateClient(VariablesStore.BaseHttpClientName)
        };

        var client = GrpcChannel.ForAddress(address, options);
        _channels.Add(client);

        return client.CreateGrpcService<T>();
    }

    public void Dispose()
    {
        foreach (var channel in _channels)
        {
            channel.Dispose();
        }
    }
}
