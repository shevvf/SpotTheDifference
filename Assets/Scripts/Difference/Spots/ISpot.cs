using Difference.Game.DifferenceStateMachine;
using Difference.Infrastructure.Services.SpotsHolderService;

namespace Difference.Spots
{
    public interface ISpot
    {
        int Id { get; set; }

        DifferenceMachine DifferenceMachine { get; }

        ISpotHolder SpotHolder { get; }

    }
}