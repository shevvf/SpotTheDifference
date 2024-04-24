using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Difference.Infrastructure.AssetManagement.AssetsProvider
{
    public interface IAssetProvider
    {
        Task InitializeAsync();
        Task<TAsset> Load<TAsset>(AssetReference assetReference) where TAsset : class;
        Task<TAsset> Load<TAsset>(string key) where TAsset : class;
        Task<List<string>> GetAssetsListByLabel<TAsset>(string label);
        Task<List<string>> GetAssetsListByLabel(string label, Type type = null);
        Task<TAsset[]> LoadAll<TAsset>(List<string> keys) where TAsset : class;
        Task WarmupAssetsByLabel(string label);
        Task ReleaseAssetsByLabel(string label);
        void Cleanup();
    }
}