using System.Runtime.Serialization;

namespace Core.Contracts.Grpc.Models.Account.Users;

[DataContract]
public class RemoveUserRequestV1
{
    [DataMember(Order = 1)]
    public required string Id { get; set; }
}
