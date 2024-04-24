using Difference.Game.DifferenceStateMachine;
using Difference.Game.DifferenceStateMachine.States;
using Difference.Game.EntryPoint;
using Difference.Game.GameplayStateMachine;
using Difference.Game.GameplayStateMachine.States;
using Difference.GameLevel;
using Difference.Infrastructure.Services.DestroyableService;
using Difference.Infrastructure.Services.HitService;
using Difference.Infrastructure.Services.SpotsHolderService;
using Difference.Infrastructure.Services.TimerService;
using Difference.LifetimeScopes.Installers;
using Difference.PlayerController;
using Difference.Purchaser;
using Difference.Spots;
using Difference.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Difference.LifetimeScopes
{
    public class GameplayScope : LifetimeScope
    {
        [field: SerializeField] public UIMainView UIMainView { get; private set; }

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<EntryGameplay>(Lifetime.Singleton);

            builder.Register<UIMainPresenter>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();

            builder.Register<TimerService>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<HitService>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<SpotHolderService>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<DestroyableService>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<SpotsConstructor>(Lifetime.Singleton).AsImplementedInterfaces();

            builder.Register<Player>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<Level>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<Win>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<Lose>(Lifetime.Singleton).AsImplementedInterfaces();

            builder.Register<IAPEffect>(Lifetime.Singleton).AsSelf();

            builder.RegisterInstance(UIMainView);

            new StateMachineInstaller<DifferenceMachine, IDifferenceState>().Install(builder);
            new StateMachineInstaller<GameplayMachine, IGameplayState>().Install(builder);
        }
    }
}