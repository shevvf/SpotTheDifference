using Difference.GameLevel;
using Difference.Infrastructure.AbstractStateMachine.States;
using Difference.Infrastructure.AssetsManagement.AssetsPath;
using Difference.Infrastructure.Factories;
using Difference.Infrastructure.Services.SpotsHolderService;
using Difference.Spots;
using UnityEngine;

namespace Difference.Game.DifferenceStateMachine.States
{
    public class DifferenceFound : IDifferenceState, IEnterParam
    {
        private readonly ILevelModel levelModel;
        private readonly ISpotHolder spotHolder;
        private readonly IFactory factory;

        public DifferenceFound(ILevelModel levelModel, ISpotHolder spotHolder, IFactory factory)
        {
            this.levelModel = levelModel;
            this.spotHolder = spotHolder;
            this.factory = factory;
        }

        public void Enter() { }

        public void EnterParam(object param)
        {
            int spotId = (int)param;
            if (!spotHolder.SpotMapping.ContainsKey(spotId)) return;

            SpotPair spotPair = spotHolder.SpotMapping[spotId];
            spotHolder.SpotMapping.Remove(spotId);
            levelModel.DifferenceCount--;

            Transform spot1 = spotPair.DefaultSpot.transform;
            Transform spot2 = spotPair.AdditionalSpot.transform;

            factory.CreateResource(DifferencePath.DIFFERENCE_FOUND, spot1.position, Quaternion.identity, spot1);
            factory.CreateResource(DifferencePath.DIFFERENCE_FOUND, spot2.position, Quaternion.identity, spot2);
        }

        public void Exit()
        {
        }
    }
}
