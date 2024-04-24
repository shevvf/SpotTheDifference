using Difference.Infrastructure.Services.TimerService;
using Difference.PlayerController;
using Difference.UI;

namespace Difference.GameLevel
{
    public class Level : ILevel
    {
        private readonly UIMainPresenter uIMainPresenter;
        private readonly ILevelModel levelModel;
        private readonly ITimer timer;
        private readonly IWin win;
        private readonly ILose lose;

        public Level(UIMainPresenter uIMainPresenter, ILevelModel levelModel, ITimer timer, IWin win, ILose lose)
        {
            this.uIMainPresenter = uIMainPresenter;
            this.levelModel = levelModel;
            this.timer = timer;
            this.win = win;
            this.lose = lose;
        }

        public void Initialize()
        {
            InitializeModel();
            InitializeView();
        }

        private void InitializeModel()
        {
            timer.OnTimerEnded += LevelLose;
            levelModel.OnDifferenceEnded += LevelWin;

            levelModel.Construct(LevelData.DIFFERENCE_COUNT);
        }

        private void InitializeView()
        {
            uIMainPresenter.Initialize();
        }

        public void Stop()
        {
            timer.OnTimerEnded -= LevelLose;
            levelModel.OnDifferenceEnded -= LevelWin;
            uIMainPresenter.Stop();
        }

        public void Dispose()
        {
            Stop();
        }

        private void LevelWin()
        {
            win.Win();
        }

        private void LevelLose()
        {
            lose.Lose();
        }
    }
}