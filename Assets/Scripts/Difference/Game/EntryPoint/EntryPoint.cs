using Difference.Game.GameStateMachine;
using Difference.Game.GameStateMachine.States;
using VContainer.Unity;

namespace Difference.Game.EntryPoint
{
    public class EntryPoint : IStartable
    {
        private readonly GameMachine gameMachine;

        public EntryPoint(GameMachine gameMachine)
        {
            this.gameMachine = gameMachine;
        }

        public void Start()
        {
            gameMachine.Enter<GameInit>();
        }
    }
}