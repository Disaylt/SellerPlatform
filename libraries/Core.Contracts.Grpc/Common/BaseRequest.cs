using System.Runtime.Serialization;

namespace Core.Contracts.Grpc.Common;

public abstract class BaseRequest
{
    [DataMember(Order = 1)]
    public string? CorrelationId { get; set; }
}
