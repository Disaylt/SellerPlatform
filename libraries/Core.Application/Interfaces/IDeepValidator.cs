using FluentValidation.Results;
using MediatR;

namespace Core.Application.Interfaces;

public interface IDeepValidator<in TRequest> where TRequest : IBaseRequest
{
    Task<ValidationResult> Handle(TRequest request, CancellationToken cancellationToken);
}
