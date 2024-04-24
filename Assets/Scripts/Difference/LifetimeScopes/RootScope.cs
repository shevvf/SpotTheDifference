using Difference.Android;
using Difference.Data.Json;
using Difference.Game.GameStateMachine;
using Difference.Game.GameStateMachine.States;
using Difference.GameLevel;
using Difference.Infrastructure.AssetManagement.AssetsProvider;
using Difference.Infrastructure.Factories;
using Difference.Infrastructure.Services.ProgressService;
using Difference.Infrastructure.Services.SaveLoadService;
using Difference.Infrastructure.Services.SceneLoaderService;
using Difference.LifetimeScopes.Installers;
using Difference.Purchaser;
using Difference.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Difference.LifetimeScopes
{
    public class RootScope : LifetimeScope
    {
        [field: SerializeField] public PlayerJsonData PlayerJsonData { get; private set; }

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<ProgressService>(Lifetime.Singleton);

            builder.Register<SceneLoaderService>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<SaveLoadService>(Lifetime.Singleton).AsImplementedInterfaces();

            builder.Register<UILoading>(Lifetime.Singleton).AsImplementedInterfaces();

            builder.Register<AssetProvider>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<LevelFactory>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.Register<LevelModel>(Lifetime.Singleton).AsImplementedInterfaces();

            builder.Register<AppodealCore>(Lifetime.Singleton).AsSelf();
            builder.Register<AppodealInterstitial>(Lifetime.Singleton).AsSelf();
            builder.Register<IAPCore>(Lifetime.Singleton).AsSelf();
            builder.Register<AndroidPopup>(Lifetime.Singleton).AsSelf();

            builder.RegisterInstance(PlayerJsonData);

            new StateMachineInstaller<GameMachine, IGameState>().Install(builder);
        }
    }
}