using Difference.Data;
using Difference.Data.Json;
using System;
using VContainer;

namespace Difference.GameLevel
{
    public class LevelModel : ILevelModel
    {
        [Inject] private readonly PlayerJsonData playerJsonData;

        private int currentLevel;
        private int differenceCount;

        public Action OnDifferenceEnded { get; set; }

        public int DifferenceCount
        {
            get => differenceCount;
            set
            {
                if (value != differenceCount)
                {
                    differenceCount = value;
                    if (differenceCount <= 0)
                    {
                        OnDifferenceEnded?.Invoke();
                    }
                }
            }
        }

        public int CurrentLevel
        {
            get => currentLevel;
            set => currentLevel = value;
        }

        public SaveData SaveData => new() { maxLevel = CurrentLevel };

        public void Construct(int currentDifferenceCount)
        {
            currentLevel = (int)playerJsonData.PlayerMaxLevel;
            differenceCount = currentDifferenceCount;
        }
    }
}