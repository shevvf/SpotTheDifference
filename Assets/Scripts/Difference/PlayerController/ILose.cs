using System;

namespace Difference.PlayerController
{
    public interface ILose
    {
        Action OnLose { get; set; }

        void Lose();
    }
}