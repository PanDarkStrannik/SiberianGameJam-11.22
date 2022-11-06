using System;
using GameCore;

namespace GameClient
{
    public sealed class GameEndController : BaseGameManagerModuleController<GameEndModule>
    {
        private PlayerStatController _playerStats;
        private TimerController _timerController;

        private GameManager _gameManager;

        public Action<string> OnPovestkaLose;
        public Action<string> OnWin;
        public Action<string> OnStatNullLoose;

        protected override void InternalInitialize()
        {
            _gameManager = GameManager.Instance;
            _gameManager.SubscribeOnInitialize(OnGameManagerInitialize);
        }

        public void Win()
        {
            _gameManager.RefreshAllModules();
            OnWin?.Invoke(Data._winText);
        }

        private void OnGameManagerInitialize()
        {
            _playerStats = _gameManager.GetController<PlayerStatController>();
            _timerController = _gameManager.GetController<TimerController>();

            _timerController.OnTimerEnd += GameLose;
            _playerStats.OnStatsUpdated += SubscribeOnStats;
        }

        private void SubscribeOnStats()
        {
            foreach (var statController in _playerStats.StatsDataControllers)
            {
                statController.OnStatValueOppositeStart += GameLose;
            }
        }


        private void GameLose(PlayerStatController.StatDataController statDataController)
        {
            _gameManager.RefreshAllModules();
            OnStatNullLoose?.Invoke(Data.GetStringByLosedStat(statDataController.StatType));
        }

        private void GameLose()
        {
            _gameManager.RefreshAllModules();
            OnPovestkaLose?.Invoke(Data._voenkomText);
        }
    }
}
