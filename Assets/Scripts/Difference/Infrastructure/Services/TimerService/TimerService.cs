using System;
using UnityEngine;

namespace Difference.Infrastructure.Services.TimerService
{
    public class TimerService : ITimer
    {
        private TimeSpan currentTime;
        private TimeSpan targetTime;
        private bool isOn = false;

        public TimeSpan CurrentTime
        {
            get { return currentTime; }
            set { currentTime = TimeSpan.FromSeconds(Math.Min(Math.Max(value.TotalSeconds, 0), 3600)); }
        }

        public Action<TimeSpan> OnTimerTick { get; set; }
        public Action OnTimerEnded { get; set; }

        public void Initialize()
        {
            currentTime = TimeSpan.FromSeconds(TimerSettings.BASE_TIME);
            targetTime = TimeSpan.FromSeconds(TimerSettings.TARGET_TIME);
            isOn = true;
        }

        public void Stop()
        {
            isOn = false;
        }

        public void PostTick()
        {
            if (!isOn) return;

            currentTime = currentTime.Subtract(TimeSpan.FromSeconds(Time.deltaTime));
            TimerTick();
            if (currentTime <= targetTime)
            {
                TimerEnd();
            }
        }

        public void TimerTick() => OnTimerTick?.Invoke(currentTime);

        public void TimerEnd() => OnTimerEnded?.Invoke();
    }
}