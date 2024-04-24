using Difference.Infrastructure.AbstractStateMachine.States;
using System.Collections.Generic;

namespace Difference.Infrastructure.AbstractStateMachine
{
    public interface IStateMachine
    {
        void Enter<TState>() where TState : class, IState;

        void EnterParam<TState>(object param) where TState : class, IEnterParam;

        void RegisterStates<TState>(IEnumerable<TState> states) where TState : class, IExitable;
    }
}