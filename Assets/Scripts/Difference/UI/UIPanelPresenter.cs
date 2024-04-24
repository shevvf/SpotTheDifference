using Difference.Game.GameplayStateMachine;
using Difference.Game.GameplayStateMachine.States;
using Difference.GameLevel;
using Difference.Infrastructure.AssetManagement.AssetsProvider;
using Difference.Infrastructure.Services.DestroyableService;
using Difference.Infrastructure.Services.SaveLoadService;
using VContainer.Unity;

namespace Difference.UI
{
    public class UIPanelPresenter : IStartable
    {
        private readonly UIPanelView view;
        private readonly GameplayMachine gameplayMachine;
        private readonly AppodealInterstitial appodealInterstitial;
        private readonly IDestroyable destroyable;
        private readonly ILevelModel levelModel;
        private readonly ISaveLoad saveLoad;
        private readonly IAssetProvider assetProvider;

        public UIPanelPresenter(UIPanelView view, GameplayMachine gameplayMachine, AppodealInterstitial appodealInterstitial, IDestroyable destroyable, ILevelModel levelModel, ISaveLoad saveLoad, IAssetProvider assetProvider)
        {
            this.view = view;
            this.gameplayMachine = gameplayMachine;
            this.appodealInterstitial = appodealInterstitial;
            this.levelModel = levelModel;
            this.saveLoad = saveLoad;
            this.assetProvider = assetProvider;
            this.destroyable = destroyable;
        }

        public void Start()
        {
            view.Restart.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            appodealInterstitial.ShowInterstitial();
            levelModel.CurrentLevel++;
            saveLoad.Save();

            assetProvider.Cleanup();
            destroyable.Destroy();

            gameplayMachine.Enter<GameplayStart>();
        }
    }
}