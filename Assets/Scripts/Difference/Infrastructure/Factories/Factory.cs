using System.Threading.Tasks;
using UnityEngine;

namespace Difference.Infrastructure.Factories
{
    public class Factory : IFactory
    {
        public Task<GameObject> CreateAddressable(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent = null)
        {
            return Task.FromResult(Object.Instantiate(prefab, position, rotation, parent));
        }

        public Task<GameObject> CreateResource(string prefabPath, Vector3 position, Quaternion rotation, Transform parent = null)
        {
            return Task.FromResult(Object.Instantiate(LoadPrefab(prefabPath), position, rotation, parent));
        }

        private GameObject LoadPrefab(string path)
        {
            return Resources.Load<GameObject>(path);
        }
    }
}
