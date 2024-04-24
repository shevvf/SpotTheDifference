using Difference.Game.DifferenceStateMachine.States;
using Difference.Spots;
using UnityEngine;

namespace Difference.Infrastructure.Services.HitService
{
    public class HitService : IHit
    {
        private bool isOn = false;

        public void Initialize()
        {
            isOn = true;
        }

        public void Stop()
        {
            isOn = false;
        }

        public void Tick()
        {
            if (Input.touchCount == 0 || !isOn) return;

            Touch touch = Input.GetTouch(0);
            if (touch.phase != TouchPhase.Began) return;

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
            if (hit.collider == null) return;

            ISpot spot = hit.collider.GetComponent<ISpot>();
            spot.DifferenceMachine.EnterParam<DifferenceFound>(spot.Id);
        }
    }
}