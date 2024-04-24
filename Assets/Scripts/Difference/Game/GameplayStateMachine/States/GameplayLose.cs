using Difference.Infrastructure.AssetsManagement.AssetsPath;
using Difference.Infrastructure.Factories;
using Difference.UI;
using UnityEngine;

namespace Difference.Game.GameplayStateMachine.States
{
    public class GameplayLose : IGameplayState
    {
        private readonly UIMainView uIMain;
        private readonly IFactory factory;

        public GameplayLose(UIMainView uIMain, IFactory factory)
        {
            this.uIMain = uIMain;
            this.factory = factory;
        }

        public void Enter()
        {
            factory.CreateResource(UIPath.LOSE_PANEL, uIMain.Canvas.position, Quaternion.identity, uIMain.Canvas);
        }

        public void Exit()
        {

        }
    }
}