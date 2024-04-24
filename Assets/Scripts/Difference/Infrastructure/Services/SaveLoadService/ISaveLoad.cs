using System;

namespace Difference.Infrastructure.Services.SaveLoadService
{
    public interface ISaveLoad
    {
        Action OnSave { get; set; }
        Action OnLoad { get; set; }

        void Save();

        void Load();
    }
}