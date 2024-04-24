using Difference.Infrastructure.AssetsManagement.AssetsPath;
using Difference.Infrastructure.Factories;
using Difference.Purchaser;
using Difference.UI;

namespace Difference.Game.GameplayStateMachine.States
{
    public class GameplayStart : IGameplayState
    {
        private readonly GameplayMachine gameplayMachine;
        private readonly LevelFactory levelFactory;
        private readonly IUILoading uILoading;

        public GameplayStart(GameplayMachine gameplayMachine, LevelFactory levelFactory,IUILoading uILoading)
        {
            this.gameplayMachine = gameplayMachine;
            this.levelFactory = levelFactory;
            this.uILoading = uILoading;
        }

        public async void Enter()
        {
            uILoading.Show();

            await levelFactory.CreateLevel($"{AddressablePath.LEVELS}1");
            gameplayMachine.Enter<GameplayLoop>();

            uILoading.Hide();
        }

        public void Exit()
        {
        }
    }
}
