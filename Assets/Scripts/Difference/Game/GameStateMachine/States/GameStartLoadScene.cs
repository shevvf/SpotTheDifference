using Difference.Infrastructure.AssetsManagement.AssetsPath;
using Difference.Infrastructure.Services.SceneLoaderService;

namespace Difference.Game.GameStateMachine.States
{
    public class GameStartLoad : IGameState
    {
        private readonly ISceneLoader sceneLoader;

        public GameStartLoad(ISceneLoader sceneLoader)
        {
            this.sceneLoader = sceneLoader;
        }

        public async void Enter()
        {
            await sceneLoader.Load(ScenePath.GAME_SCENE_NAME);
        }

        public void Exit()
        {
        }
    }
}