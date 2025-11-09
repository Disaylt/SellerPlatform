using System.Runtime.Serialization;

namespace Core.Contracts.Grpc.Models.Account.Identity;

[DataContract]
public class NewSessionRequestV1
{
    [DataMember(Order = 1)]
    public required string Id { get; set; }

    [DataMember(Order = 2)]
    public required string Email { get; set; }

    [DataMember(Order = 3)]
    public required string Login { get; set; }
}
