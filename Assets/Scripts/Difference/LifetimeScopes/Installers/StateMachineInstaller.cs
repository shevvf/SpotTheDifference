using Difference.Infrastructure.AbstractStateMachine;
using Difference.Infrastructure.AbstractStateMachine.States;
using Framework.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using VContainer;
using VContainer.Unity;

namespace Difference.LifetimeScopes.Installers
{
    public class StateMachineInstaller<TMachine, TStates> : IInstaller
        where TMachine : IStateMachine
        where TStates : class, IExitable
    {
        public void Install(IContainerBuilder builder)
        {
            builder.Register<TMachine>(Lifetime.Singleton).AsSelf();

            var stateTypes = Assembly
                  .GetExecutingAssembly()
                  .GetTypes()
                  .Where(type => typeof(TStates).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract);

            stateTypes.ForEach(type => builder.Register(type, Lifetime.Scoped).AsImplementedInterfaces());

            builder.RegisterBuildCallback(container =>
            {
                var stateMachine = container.Resolve<TMachine>();
                var states = container.Resolve<IEnumerable<TStates>>();
                stateMachine.RegisterStates(states);
            });
        }
    }
}