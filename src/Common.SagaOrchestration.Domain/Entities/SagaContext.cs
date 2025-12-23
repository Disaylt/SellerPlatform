using Common.SagaOrchestration.Domain.Enums;
using Common.SagaOrchestration.Domain.Interfaces;

namespace Common.SagaOrchestration.Domain.Entities;

public class SagaContext
{
    public string Id { get; private set; } = Guid.NewGuid().ToString();
    public SagaStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
    public string StepState { get; private set; }
    public string Type { get; private set; }

    public IList<SagaStep> Steps { get; set; } = [];


    private ISagaStepMachine? _stepStateMachine;

    public SagaContext(
        ISagaStepMachine sagaStateMachine)
    {
        Type = sagaStateMachine.Name;
        StepState = sagaStateMachine.FirstStep;

        _stepStateMachine = sagaStateMachine;
    }

    public SagaContext SetStateMachine(ISagaStepMachine sagaStepStateMachine)
    {
        if(Type != sagaStepStateMachine.Name)
        {
            throw new NullReferenceException($"State machine is not equals context type. State machin - {sagaStepStateMachine.Name} | Context type - {Type}");
        }

        _stepStateMachine = sagaStepStateMachine;

        return this;
    }

    public void StepFail()
    {

    }

    public void StepComplete()
    {
        if(StepState == _stepStateMachine?.FirstStep)
        {

        }
    }
}
