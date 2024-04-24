using Difference.Infrastructure.AssetManagement.AssetsProvider;
using Difference.Infrastructure.Services.SaveLoadService;
using Difference.Purchaser;
using Difference.UI;
using System.Threading.Tasks;

namespace Difference.Game.GameStateMachine.States
{
    public class GameInit : IGameState
    {
        private readonly GameMachine gameMachine;
        private readonly AppodealCore appodealCore;
        private readonly IAPCore iAPCore;
        private readonly IUILoading uILoading;
        private readonly IAssetProvider assetProvider;
        private readonly ISaveLoad saveLoad;

        public GameInit(GameMachine gameMachine, AppodealCore appodealCore, IAPCore iAPCore, IUILoading uILoading, IAssetProvider assetProvider, ISaveLoad saveLoad)
        {
            this.appodealCore = appodealCore;
            this.iAPCore = iAPCore;
            this.gameMachine = gameMachine;
            this.saveLoad = saveLoad;
            this.assetProvider = assetProvider;
            this.uILoading = uILoading;
        }

        public async void Enter()
        {
            await Initialize();
            gameMachine.Enter<GameStartLoad>();
        }

        public void Exit()
        {
        }

        private async Task Initialize()
        {
            saveLoad.Load();
            uILoading.Initialize();
            appodealCore.Initialize();
            iAPCore.Initialize();
            await assetProvider.InitializeAsync();
        }
    }
}