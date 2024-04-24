using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Difference.Infrastructure.AssetManagement.AssetsProvider
{
    public class AssetProvider : IAssetProvider
    {
        private readonly Dictionary<string, AsyncOperationHandle> assetRequests = new();

        public async Task InitializeAsync()
        {
            await Addressables.InitializeAsync().Task;
        }

        public async Task<TAsset> Load<TAsset>(string key) where TAsset : class
        {
            if (!assetRequests.TryGetValue(key, out AsyncOperationHandle handle))
            {
                handle = Addressables.LoadAssetAsync<TAsset>(key);
                assetRequests.Add(key, handle);

            }
            await handle.Task;
            return handle.Result as TAsset;
        }

        public async Task<TAsset> Load<TAsset>(AssetReference assetReference) where TAsset : class
        {
            return await Load<TAsset>(assetReference.AssetGUID);
        }

        public async Task<List<string>> GetAssetsListByLabel<TAsset>(string label)
        {
            return await GetAssetsListByLabel(label, typeof(TAsset));
        }

        public async Task<List<string>> GetAssetsListByLabel(string label, Type type = null)
        {
            var operationHandle = Addressables.LoadResourceLocationsAsync(label, type);

            var locations = await operationHandle.Task;

            List<string> assetKeys = new(locations.Count);

            foreach (var location in locations)
                assetKeys.Add(location.PrimaryKey);

            Addressables.Release(operationHandle);

            return assetKeys;
        }

        public async Task<TAsset[]> LoadAll<TAsset>(List<string> keys) where TAsset : class
        {
            List<Task<TAsset>> tasks = new(keys.Count);

            foreach (var key in keys)
                tasks.Add(Load<TAsset>(key));

            return await Task.WhenAll(tasks);
        }

        public async Task WarmupAssetsByLabel(string label)
        {
            var assetsList = await GetAssetsListByLabel(label);
            await LoadAll<object>(assetsList);
        }

        public async Task ReleaseAssetsByLabel(string label)
        {
            var assetsList = await GetAssetsListByLabel(label);

            foreach (var assetKey in assetsList)
            {
                if (assetRequests.TryGetValue(assetKey, out var handler))
                {
                    Addressables.Release(handler);
                    assetRequests.Remove(assetKey);
                }
            }
        }

        public void Cleanup()
        {
            foreach (var assetRequest in assetRequests)
            {
                Addressables.Release(assetRequest.Value);
            }
            assetRequests.Clear();
        }
    }
}