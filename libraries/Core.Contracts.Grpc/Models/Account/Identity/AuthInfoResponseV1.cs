using System.Runtime.Serialization;

namespace Core.Contracts.Grpc.Models.Account.Identity;

[DataContract]
public class AuthInfoResponseV1
{
    [DataMember(Order = 1)]
    public required string AccessToken { get; set; }

    [DataMember(Order = 2)]
    public required string RefreshToken { get; set; }
}
