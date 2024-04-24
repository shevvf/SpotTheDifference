using Difference.Spots;
using System.Collections.Generic;

namespace Difference.Infrastructure.Services.SpotsHolderService
{
    public interface ISpotHolder
    {
        void AddDefaultSpot(DefaultSpot defaultSpot);

        void AddAdditionalSpot(AdditionalSpot additionalSpot);

        void CreateSpotPairs();

        void Clear();

        public Dictionary<int, SpotPair> SpotMapping { get; set; }
    }
}