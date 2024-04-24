using System;
using VContainer.Unity;

namespace Difference.Infrastructure.Services.ProgressService
{
    public interface IProgress : IStartable, IDisposable
    {
        void Load();
        void Save();
    }
}