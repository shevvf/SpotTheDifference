using Difference.Android;
using Difference.GameLevel;
using Difference.Infrastructure.Services.TimerService;
using Difference.Purchaser;
using System;
using UnityEngine;

namespace Difference.UI
{
    public class UIMainPresenter : IDisposable
    {
        private readonly UIMainView view;
        private readonly IAPEffect iAPEffect;
        private readonly AndroidPopup androidPopup;
        private readonly ILevelModel levelModel;
        private readonly ITimer timer;

        public UIMainPresenter(UIMainView view, IAPEffect iAPEffect,AndroidPopup androidPopup, ILevelModel levelModel, ITimer timer)
        {
            this.view = view;
            this.iAPEffect = iAPEffect;
            this.androidPopup = androidPopup;
            this.levelModel = levelModel;
            this.timer = timer;
        }

        public void Initialize()
        {
            InitializeView();

            if (Application.isEditor)
                return;
            view.IAP.onClick.AddListener(Buy);
        }

        public void Stop()
        {
            timer.OnTimerTick -= UpdateTimer;

            if (Application.isEditor)
                return;
            view.IAP.onClick.RemoveAllListeners();
        }

        public void Dispose()
        {
            Stop();
        }

        private void InitializeView()
        {
            timer.OnTimerTick += UpdateTimer;
            UpdateLevel();
        }

        private void UpdateTimer(TimeSpan time)
        {
            view.Timer.SetText($"Время: {time:mm\\:ss}");
        }

        private void UpdateLevel()
        {
            view.Level.SetText($"Уровень: {levelModel.CurrentLevel}");
        }

        private void Buy()
        {
            iAPEffect.AddTime(10d);
            androidPopup.ShowPopup("Unity IAP", "Добавлено 10 секунд (отмену покупки можно протестировать в unity)");
        }
    }
}