using System;

namespace Difference.PlayerController
{
    public class Win : IWin
    {
        public Action OnWin { get; set; }

        void IWin.Win() => OnWin?.Invoke();
    }
}