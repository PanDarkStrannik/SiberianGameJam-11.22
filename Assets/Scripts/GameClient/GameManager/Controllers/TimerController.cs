using System;
using System.Collections;
using GameCore;
using GameCore.Utils;

namespace GameClient
{
    public class TimerController : BaseGameManagerModuleController<TimerModule>
    {
        public event Action OnTimerEnd;
        public event Action<int> OnTick; 

        private GameManager _gameManager;
        private Scheduler _timer;

        protected override void InternalInitialize()
        {
            _gameManager = GameManager.Instance;
            _timer = new Scheduler(Data.TimeStep);
            _timer.OnFinished += OnTimerEnd;
            _timer.OnTick += OnTick;
        }

        private void StartTimer()
        {
            _timer.Start(Data.TimeToEnd);
        }
    }
}
