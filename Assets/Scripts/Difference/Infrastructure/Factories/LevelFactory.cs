using Difference.Infrastructure.AssetManagement.AssetsProvider;
using System.Threading.Tasks;
using UnityEngine;

namespace Difference.Infrastructure.Factories
{
    public class LevelFactory : Factory
    {
        private readonly IAssetProvider assetProvider;

        public LevelFactory(IAssetProvider assetProvider)
        {
            this.assetProvider = assetProvider;
        }

        public async Task<GameObject> CreateLevel(string assetKey)
        {
            GameObject levelPrefab = await assetProvider.Load<GameObject>(assetKey);

            return await CreateAddressable(levelPrefab, Vector3.zero, Quaternion.identity);
        }
    }
}