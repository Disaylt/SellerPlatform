using System.Runtime.Serialization;
using Core.Contracts.Grpc.Common;

namespace Core.Contracts.Grpc.Models.Account.Identity;

[DataContract] 
public class NewAuthInfoRequestV1 : BaseRequest
{
    [DataMember(Order = 2)]
    public required string UserId { get; set; }

    [DataMember(Order = 3)]
    public required string SessionId { get; set; }

    [DataMember(Order = 4)]
    public IEnumerable<string> Roles { get; set; } = [];
}
