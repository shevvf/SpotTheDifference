using System;

namespace Difference.PlayerController
{
    public interface IWin
    {
        Action OnWin { get; set; }

        void Win();
    }
}