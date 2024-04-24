using Difference.Infrastructure.AssetsManagement.AssetsPath;
using Difference.Infrastructure.Factories;
using UnityEngine;

namespace Difference.UI
{
    public class UILoading : IUILoading
    {
        private readonly IFactory factory;

        private GameObject loadingCanvas;

        public UILoading(IFactory factory)
        {
            this.factory = factory;
        }

        public async void Initialize()
        {
            loadingCanvas = await factory.CreateResource(UIPath.LOADING_CANVAS, Vector3.zero, Quaternion.identity);
            Object.DontDestroyOnLoad(loadingCanvas);
        }

        public void Show()
        {
            loadingCanvas.SetActive(true);
        }

        public void Hide()
        {
            loadingCanvas.SetActive(false);
        }
    }
}