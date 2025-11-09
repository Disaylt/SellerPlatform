using Core.Contracts.Config.Common;
namespace Core.Contracts.Config.SolutionConfig.ExternalServices.Account.Identity;

public class IdentityModel
{
    public GrpcServiceConfig Grpc { get; set; } = new();
}
