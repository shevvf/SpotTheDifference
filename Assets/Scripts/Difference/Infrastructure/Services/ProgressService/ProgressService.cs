using Difference.Data.Json;
using Difference.Data.Path;
using Difference.GameLevel;
using Difference.Infrastructure.Services.SaveLoadService;
using Newtonsoft.Json.Linq;

namespace Difference.Infrastructure.Services.ProgressService
{
    public class ProgressService : IProgress
    {
        private readonly PlayerJsonData playerJsonData;
        private readonly ISaveLoad saveLoad;
        private readonly ILevelModel levelModel;

        public ProgressService(ISaveLoad saveLoad, PlayerJsonData playerJsonData, ILevelModel levelModel)
        {
            this.saveLoad = saveLoad;
            this.playerJsonData = playerJsonData;
            this.levelModel = levelModel;
        }

        public void Start()
        {
            saveLoad.OnLoad += Load;
            saveLoad.OnSave += Save;
        }

        public void Load()
        {
            playerJsonData.LoadData(DataPath.PLAYER_DATA);
        }

        public void Save()
        {
            playerJsonData.Data[DataPath.PLAYER_DATA] = JObject.FromObject(levelModel.SaveData);
            playerJsonData.SaveData();
        }

        public void Dispose()
        {
            saveLoad.OnLoad -= Load;
            saveLoad.OnSave -= Save;
        }
    }
}