using System.Runtime.Serialization;

namespace Core.Contracts.Grpc.Models.Account.Users;

[DataContract]
public class CreateUserRequestV1
{
    [DataMember(Order = 1)]
    public required string Password { get; set; }

    [DataMember(Order = 2)]
    public required string Email { get; set; }

    [DataMember(Order = 3)]
    public required string Login { get; set; }
}
