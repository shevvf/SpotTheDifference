namespace Difference.Spots
{
    public class SpotPair
    {
        public DefaultSpot DefaultSpot { get; private set; }
        public AdditionalSpot AdditionalSpot { get; private set; }

        public SpotPair(DefaultSpot defaultSpot, AdditionalSpot additionalSpot)
        {
            DefaultSpot = defaultSpot;
            AdditionalSpot = additionalSpot;
        }
    }
}