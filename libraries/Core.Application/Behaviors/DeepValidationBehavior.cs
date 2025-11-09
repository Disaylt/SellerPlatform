using Core.Abstraction.Exceptions;
using Core.Application.Helpers;
using Core.Application.Interfaces;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Behaviors;

public class DeepValidationBehavior<TRequest, TResponse>(IEnumerable<IDeepValidator<TRequest>> validators)
        : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<ValidationResult> deepValidateResults = await HandleValidatorsAsync(request, cancellationToken);

        var exceptions = ValidationHelper.CollectErrorDetails(deepValidateResults);

        if (exceptions.Length > 0)
        {
            throw ValidationHelper.CreateException(exceptions);
        }

        return await next(cancellationToken);
    }

    private async Task<IReadOnlyCollection<ValidationResult>> HandleValidatorsAsync(TRequest request, CancellationToken cancellationToken)
    {
        if (validators.Any() == false)
        {
            return [];
        }

        List<ValidationResult> deepValidateResults = [];

        foreach (var validator in validators)
        {
            var result = await validator.Handle(request, cancellationToken);
                deepValidateResults.Add(result);
        }

        return deepValidateResults;
    }
}
