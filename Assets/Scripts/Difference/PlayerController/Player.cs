using Difference.Game.GameplayStateMachine;
using Difference.Game.GameplayStateMachine.States;

namespace Difference.PlayerController
{
    public class Player : IPlayer
    {
        private readonly GameplayMachine gameplayMachine;

        private readonly IWin win;
        private readonly ILose lose;

        public Player(GameplayMachine gameplayMachine, IWin win, ILose lose)
        {
            this.gameplayMachine = gameplayMachine;
            this.win = win;
            this.lose = lose;
        }

        public void Initialize()
        {
            win.OnWin += Win;
            lose.OnLose += Lose;
        }

        public void Dispose()
        {
            win.OnWin -= Win;
            lose.OnLose -= Lose;
        }

        private void Win()
        {
            gameplayMachine.Enter<GameplayWin>();
        }

        private void Lose()
        {
            gameplayMachine.Enter<GameplayLose>();
        }
    }
}