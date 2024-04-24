using Difference.Game.Loop;
using System;
using VContainer.Unity;

namespace Difference.Infrastructure.Services.TimerService
{
    public interface ITimer : IPostTickable, IGameLoop
    {
        TimeSpan CurrentTime { get; set; }
        Action<TimeSpan> OnTimerTick { get; set; }
        Action OnTimerEnded { get; set; }
        void TimerTick();
        void TimerEnd();
    }
}