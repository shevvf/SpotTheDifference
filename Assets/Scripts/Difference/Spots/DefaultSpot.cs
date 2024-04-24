namespace Difference.Spots
{
    public class DefaultSpot : AbstractSpot
    {
        protected override void AddSpot()
        {
            SpotHolder.AddDefaultSpot(this);
        }
    }
}