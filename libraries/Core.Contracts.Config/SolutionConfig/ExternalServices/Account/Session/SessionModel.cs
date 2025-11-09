using Core.Contracts.Config.Common;

namespace Core.Contracts.Config.SolutionConfig.ExternalServices.Account.Session;

public class SessionModel
{
    public GrpcServiceConfig Grpc { get; set; } = new();
}
