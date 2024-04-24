using System;

namespace Difference.Infrastructure.Services.DestroyableService
{
    public interface IDestroyable
    {
        Action OnDestroy { get; set; }

        void Destroy();
    }
}