using System.Runtime.Serialization;

namespace Core.Contracts.Grpc.Models.Account.Identity;

[DataContract]
public class NewAuthInfoRequestV1
{
    [DataMember(Order = 1)]
    public required string UserId { get; set; }

    [DataMember(Order = 2)]
    public required string SessionId { get; set; }
}
