using Core.Contracts.Config.Common;

namespace Core.Contracts.Config.SolutionConfig.ExternalServices.Account.User;

public class UserModel
{
    public GrpcServiceConfig Grpc { get; set; } = new();
}
