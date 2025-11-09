using System.ServiceModel;
using Core.Contracts.Grpc.Models.Account.Users;

namespace Core.Contracts.Grpc.Services.Account.Users;

[ServiceContract]
public interface IUserExternalService
{
    [OperationContract]
    Task<CreateUserResponseV1> CreateV1Async(CreateUserRequestV1 request);

    [OperationContract]
    Task RemoveV1Async(RemoveUserRequestV1 request);
}
