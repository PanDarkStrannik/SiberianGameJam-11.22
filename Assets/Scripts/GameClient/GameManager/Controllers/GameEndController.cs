using GameCore;

namespace GameClient
{
    public sealed class GameEndController : BaseGameManagerModuleController<GameEndModule>
    {
        private PlayerStatController _playerStats;
        private TimerController _timerController;

        private GameManager _gameManager;
        protected override void InternalInitialize()
        {
            _gameManager = GameManager.Instance;
            _gameManager.SubscribeOnInitialize(OnGameManagerInitialize);
        }

        public void Win()
        {
            _gameManager.RefreshAllModules();
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
        }

        private void GameLose()
        {
            _gameManager.RefreshAllModules();
        }
    }
}
