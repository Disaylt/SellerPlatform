using System.ServiceModel;
using Core.Contracts.Grpc.Models.Account.Identity;

namespace Core.Contracts.Grpc.Services.Account.Identity;

[ServiceContract]
public interface IIdentityExternalService
{
    [OperationContract]
    Task<AuthInfoResponseV1> CreateAuthInfoV1(NewAuthInfoRequestV1 request);
}
