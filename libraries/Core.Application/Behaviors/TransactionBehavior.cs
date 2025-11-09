using Core.Abstraction.Interfaces;
using Core.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Behaviors;

public class TransactionBehavior<TRequest, TResponse>(ITransactionManager transactionManager,
    ILogger<TransactionBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse> where TRequest : ITransactionRequest
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            if (transactionManager.HasTransaction)
            {
                return await next(cancellationToken);
            }

            await transactionManager.BeginTransactionAsync(cancellationToken);

            logger.LogInformation("Create transaction.");

            TResponse response = await next(cancellationToken);

            await transactionManager.CommitAsync(cancellationToken);

            logger.LogInformation("Transaction commited.");

            return response;
        }
        catch (Exception ex)
        {
            if (transactionManager.HasTransaction)
            {
                await transactionManager.RollbackAsync(cancellationToken);
                logger.LogError(ex, "Transaction rollback.");
            }

            throw;
        }
    }
}