using Difference.GameLevel;
using Difference.Spots;
using System.Collections.Generic;

namespace Difference.Infrastructure.Services.SpotsHolderService
{
    public class SpotHolderService : ISpotHolder
    {
        private readonly List<ISpot> defaultSpots = new();
        private readonly List<ISpot> additionalSpots = new();
        private readonly List<SpotPair> spotPairs = new();

        public Dictionary<int, SpotPair> SpotMapping { get; set; } = new();

        public void AddDefaultSpot(DefaultSpot defaultSpot)
        {
            defaultSpots.Add(defaultSpot);
        }

        public void AddAdditionalSpot(AdditionalSpot additionalSpot)
        {
            additionalSpots.Add(additionalSpot);
        }

        public void CreateSpotPairs()
        {
            for (int i = 0; i < LevelData.DIFFERENCE_COUNT; i++)
            {
                spotPairs.Add(new((DefaultSpot)defaultSpots[i], (AdditionalSpot)additionalSpots[i]));
                SetSpotId(i);
                MapSpots(i);
            }
        }

        public void Clear()
        {
            defaultSpots.Clear();
            additionalSpots.Clear();
            spotPairs.Clear();
            SpotMapping.Clear();
        }

        private void SetSpotId(int id)
        {
            defaultSpots[id].Id = id;
            additionalSpots[id].Id = id;
        }

        private void MapSpots(int id)
        {
            SpotMapping.Add(id, spotPairs[id]);
        }
    }
}