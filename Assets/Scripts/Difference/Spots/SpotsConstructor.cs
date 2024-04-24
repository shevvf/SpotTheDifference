using Difference.Game.Loop;
using Difference.Infrastructure.Services.SpotsHolderService;

namespace Difference.Spots
{
    public class SpotsConstructor : IGameLoop
    {
        private readonly ISpotHolder spotHolder;

        public SpotsConstructor(ISpotHolder spotHolder)
        {
            this.spotHolder = spotHolder;
        }

        public void Initialize()
        {
            spotHolder.CreateSpotPairs();
        }

        public void Stop()
        {
            spotHolder.Clear();
        }
    }
}
