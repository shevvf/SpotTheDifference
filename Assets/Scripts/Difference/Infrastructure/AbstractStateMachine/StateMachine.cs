using Difference.Infrastructure.AbstractStateMachine.States;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Difference.Infrastructure.AbstractStateMachine
{
    public abstract class StateMachine : IStateMachine
    {
        private IExitable currentState;
        private Dictionary<Type, IExitable> registeredStates = new();

        public void Enter<TState>() where TState : class, IState
        {
            TState newState = ChangeState<TState>();
            newState.Enter();
        }

        public void EnterParam<TState>(object param) where TState : class, IEnterParam
        {
            TState newState = ChangeState<TState>();
            newState.EnterParam(param);
        }

        public void RegisterStates<TState>(IEnumerable<TState> states) where TState : class, IExitable
        {
            registeredStates = states.ToDictionary(state => state.GetType(), state => (IExitable)state);
        }

        private TState ChangeState<TState>() where TState : class, IExitable
        {
            currentState?.Exit();

            TState state = GetState<TState>();
            currentState = state;
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitable
        {
            return registeredStates[typeof(TState)] as TState;
        }
    }
}