using Difference.Data;
using System;

namespace Difference.GameLevel
{
    public interface ILevelModel
    {
        Action OnDifferenceEnded { get; set; }
        int CurrentLevel { get; set; }
        int DifferenceCount { get; set; }
        SaveData SaveData { get; }
        void Construct(int currentDifferenceCount);
    }
}