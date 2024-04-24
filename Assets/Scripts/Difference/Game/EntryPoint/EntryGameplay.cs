using Difference.Game.GameplayStateMachine;
using Difference.Game.GameplayStateMachine.States;
using VContainer.Unity;

namespace Difference.Game.EntryPoint
{
    public class EntryGameplay : IStartable
    {
        private readonly GameplayMachine gameplayMachine;

        public EntryGameplay(GameplayMachine gameplayMachine)
        {
            this.gameplayMachine = gameplayMachine;
        }

        public void Start()
        {
            gameplayMachine.Enter<GameplayInit>();
        }
    }
}