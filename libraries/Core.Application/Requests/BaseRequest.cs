using MediatR;

namespace Core.Application.Requests;

public abstract class BaseRequest<T> : IRequest<T>
{
    public string? CorrelationId { get; set; }
}
