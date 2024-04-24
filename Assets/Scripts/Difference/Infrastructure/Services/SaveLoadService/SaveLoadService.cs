using System;

namespace Difference.Infrastructure.Services.SaveLoadService
{
    public class SaveLoadService : ISaveLoad
    {
        public Action OnSave { get; set; }
        public Action OnLoad { get; set; }

        public void Save() => OnSave?.Invoke();

        public void Load() => OnLoad?.Invoke();
    }
}