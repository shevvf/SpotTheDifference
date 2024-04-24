using Difference.Game.Loop;
using System;

namespace Difference.PlayerController
{
    public interface IPlayer :  IDisposable
    {
        void Initialize();
    }
}
