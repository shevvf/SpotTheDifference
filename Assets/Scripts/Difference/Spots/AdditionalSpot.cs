namespace Difference.Spots
{
    public class AdditionalSpot : AbstractSpot
    {
        protected override void AddSpot()
        {
            SpotHolder.AddAdditionalSpot(this);
        }
    }
}