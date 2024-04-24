using Difference.Game.Loop;
using System.Collections.Generic;

namespace Difference.Game.GameplayStateMachine.States
{
    public class GameplayLoop : IGameplayState
    {
        private readonly IReadOnlyList<IGameLoopInit> gameLoopInit;
        private readonly IReadOnlyList<IGameLoopStop> gameLoopStop;

        public GameplayLoop(IReadOnlyList<IGameLoopStop> gameLoopStop, IReadOnlyList<IGameLoopInit> gameLoopInit)
        {
            this.gameLoopInit = gameLoopInit;
            this.gameLoopStop = gameLoopStop;
        }

        public void Enter()
        {
            foreach (var initiable in gameLoopInit)
            {
                initiable.Initialize();
            }
        }

        public void Exit()
        {
            foreach (var stoppable in gameLoopStop)
            {
                stoppable.Stop();
            }
        }
    }
}