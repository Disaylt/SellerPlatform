using Common.SagaOrchestration.Application.Services.Abstraction;
using Common.SagaOrchestration.Domain.Interfaces;

namespace Common.SagaOrchestration.Application.Features.Account.Users.RegisterUser;

public class RegisterUserSagaStateMachine : SagaStateMachine
{
    private Dictionary<string, string> _steps = new Dictionary<string, string>
    {

    };

    protected override Dictionary<string, string> Steps => _steps;
}
