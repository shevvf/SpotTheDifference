using Difference.Game.DifferenceStateMachine;
using Difference.Game.DifferenceStateMachine.States;
using Difference.Infrastructure.Services.SpotsHolderService;
using UnityEngine;
using VContainer;

namespace Difference.Spots
{
    public abstract class AbstractSpot : MonoBehaviour, ISpot
    {
        private DifferenceMachine differenceMachine;
        private ISpotHolder spotHolder;

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public DifferenceMachine DifferenceMachine => differenceMachine;

        public ISpotHolder SpotHolder => spotHolder;


        [Inject]
        public void Construct(DifferenceMachine differenceMachine, ISpotHolder spotHolder)
        {
            this.differenceMachine = differenceMachine;
            this.spotHolder = spotHolder;

            InitSpot();
        }

        public virtual void InitSpot()
        {
            DifferenceMachine.Enter<DifferenceInit>();
            AddSpot();
        }

        protected abstract void AddSpot();
    }
}