using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Difference.Infrastructure.Services.SceneLoaderService
{
    public class SceneLoaderService : ISceneLoader
    {
        public async Task Load(object sceneIdOrName, Action OnLoaded = null)
        {
            AsyncOperation waitNextScene = sceneIdOrName is int sceneId
                 ? SceneManager.LoadSceneAsync(sceneId)
                 : SceneManager.LoadSceneAsync(sceneIdOrName.ToString());

            while (!waitNextScene.isDone)
            {
                await Task.Yield();
            }

            OnLoaded?.Invoke();
        }
    }
}