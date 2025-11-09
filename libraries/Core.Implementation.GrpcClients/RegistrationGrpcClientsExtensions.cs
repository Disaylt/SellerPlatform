using Core.Contracts.Config.SolutionConfig;
using Core.Contracts.Grpc.Services.Account.Identity;
using Core.Contracts.Grpc.Services.Account.Users;
using Core.Implementation.GrpcClients.Abstraction;
using Core.Implementation.GrpcClients.Implementation;
using Core.Implementation.GrpcClients.Seed;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Core.Implementation.GrpcClients;

public static class RegistrationGrpcClientsExtensions
{
    public static IServiceCollection AddGrpcClients(this IServiceCollection services)
    {
        services.AddGrpcClient<ISessionExternalService>(x => x.ExternalServices.Account.Session.Grpc.Addresses);
        services.AddGrpcClient<IUserExternalService>(x => x.ExternalServices.Account.User.Grpc.Addresses);

        services.AddScoped<IGrpcChannelsFactory, GrpcChannelsFactory>();
        services.AddHttpClient(VariablesStore.BaseHttpClientName);

        return services;
    }

    public static IServiceCollection AddGrpcClient<T>(
        this IServiceCollection services,
        Func<SolutionConfigModel, IEnumerable<string>> getGrpcUrls)
        where T : class
    {
        services.AddScoped(provider =>
        {
            IOptions<SolutionConfigModel> options = provider.GetRequiredService<IOptions<SolutionConfigModel>>();

            var url = getGrpcUrls(options.Value).GetRandom();

            return provider
                .GetRequiredService<IGrpcChannelsFactory>()
                .Create<T>(url);
        });

        return services;
    }
}
