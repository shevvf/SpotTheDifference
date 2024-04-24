using System;
using System.Threading.Tasks;

namespace Difference.Infrastructure.Services.SceneLoaderService
{
    public interface ISceneLoader
    {
        Task Load(object sceneId, Action OnLoaded = null);
    }
}