using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

namespace Difference.Infrastructure.Factories
{
    public class Factory : IFactory
    {
        private readonly List<GameObject> loadedPrefabs = new();

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
            GameObject prefab = loadedPrefabs.Find(p => p.name == Path.GetFileNameWithoutExtension(path));
            if (prefab == null)
            {
                prefab = Resources.Load<GameObject>(path);
                loadedPrefabs.Add(prefab);
            }
            return prefab;
        }
    }
}
