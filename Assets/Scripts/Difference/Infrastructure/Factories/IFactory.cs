using System.Threading.Tasks;
using UnityEngine;

namespace Difference.Infrastructure.Factories
{
    public interface IFactory
    {
        Task<GameObject> CreateAddressable(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent = null);

        Task<GameObject> CreateResource(string prefabPath, Vector3 position, Quaternion rotation, Transform parent = null);
    }
}