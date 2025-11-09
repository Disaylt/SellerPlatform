using System.ServiceModel;
using Core.Contracts.Grpc.Models.Account.Identity;

namespace Core.Contracts.Grpc.Services.Account.Identity;

[ServiceContract]
public interface ISessionExternalService
{
    [OperationContract]
    Task<AuthInfoResponseV1> CreateV1Async(NewSessionRequestV1 request);
}
