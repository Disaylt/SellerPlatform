using Common.SagaOrchestration.Domain.Entities;
using Common.SagaOrchestration.Domain.Interfaces;

namespace Common.SagaOrchestration.Application.Features.Account.Users.RegisterUser.Steps;

public class CreateSessionStep : SagaStep<CreateSessionStep>
{
    public override Task<bool> CompensateAsync(SagaContext context)
    {
        throw new NotImplementedException();
    }

    public override Task ExecuteAsync(SagaContext context)
    {
        throw new NotImplementedException();
    }
}
