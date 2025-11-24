using System.Runtime.Serialization;
using Core.Contracts.Grpc.Common;

namespace Core.Contracts.Grpc.Models.Account.Identity;

[DataContract]
public class AuthInfoResponseV1
{
    [DataMember(Order = 2)]
    public required string AccessToken { get; set; }

    [DataMember(Order = 3)]
    public required string RefreshToken { get; set; }
}
