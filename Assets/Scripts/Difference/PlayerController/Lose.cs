using System;

namespace Difference.PlayerController
{
    public class Lose : ILose
    {
        public Action OnLose { get; set; }

        void ILose.Lose() => OnLose?.Invoke();
    }
}