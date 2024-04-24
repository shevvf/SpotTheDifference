using Difference.Infrastructure.Services.DestroyableService;
using UnityEngine;
using VContainer;

namespace Difference.Infrastructure.Services.DestroyableService
{
    public class DestroyableObject : MonoBehaviour
    {
        private IDestroyable destroyable;

        [Inject]
        public void Construct(IDestroyable destroyable)
        {
            this.destroyable = destroyable;
            SetAction();
        }

        private void SetAction()
        {
            destroyable.OnDestroy += DestroyObject;
        }

        private void OnDestroy()
        {
            destroyable.OnDestroy -= DestroyObject;
        }

        private void DestroyObject()
        {
            Destroy(gameObject);
        }
    }
}