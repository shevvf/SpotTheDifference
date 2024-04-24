using Difference.PlayerController;
using Difference.Purchaser;

namespace Difference.Game.GameplayStateMachine.States
{
    public class GameplayInit : IGameplayState
    {
        private readonly GameplayMachine gameplayMachine;
        private readonly IAPEffect iAPEffect;
        private readonly IPlayer player;

        public GameplayInit(GameplayMachine gameplayMachine, IAPEffect iAPEffect, IPlayer player)
        {
            this.gameplayMachine = gameplayMachine;
            this.player = player;
            this.iAPEffect = iAPEffect;
        }

        public void Enter()
        {
            player.Initialize();
            iAPEffect.InitializeLevelIAP();

            gameplayMachine.Enter<GameplayStart>();
        }

        public void Exit()
        {
        }
    }
}
