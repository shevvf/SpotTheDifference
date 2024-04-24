using System;

namespace Difference.Infrastructure.Services.DestroyableService
{
    public class DestroyableService : IDestroyable
    {
        public Action OnDestroy { get; set; }

        public void Destroy() => OnDestroy?.Invoke();
    }
}