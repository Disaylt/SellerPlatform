using Core.Abstraction.Exceptions;
using FluentValidation.Results;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Helpers;

internal static class ValidationHelper
{
    internal static CoreRequestException CreateException((string PropertyName, string ErrorMessage)[] exceptions)
    {
        var generalException = new CoreRequestException();

        foreach (var (PropertyName, ErrorMessage) in exceptions)
        {
            if (string.IsNullOrEmpty(PropertyName))
            {
                generalException.AddMessages(ErrorMessage);
            }
            else
            {
                generalException.AddKeyMessages(PropertyName, ErrorMessage);
            }
        }

        return generalException.SetStatusCode(HttpStatusCode.BadRequest);
    }

    internal static (string PropertyName, string ErrorMessage)[] CollectErrorDetails(
        IEnumerable<ValidationResult> validationResults)
    {
        return [..validationResults
            .Where(r => r.Errors.Count > 0)
            .SelectMany(r => r.Errors)
            .Select(e => (e.PropertyName, e.ErrorMessage))];
    }
}
