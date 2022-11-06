using System;
using System.Collections.Generic;
using GameCore.GameManager;
using UnityEngine;

namespace GameClient
{
    [Serializable]
    public class GameManager : BaseGameManager<GameManager.GameManagerControllerFabric, GameManager>
    {
        [SerializeField] private Canvas _targetCanvas;
        public Canvas TargetCanvas => _targetCanvas;

        public void RefreshAllModules()
        {
            foreach (var controller in Controllers)
            {
                controller.Refresh();
            }
        }

        public class GameManagerControllerFabric : BaseGameManageControllerFabric
        {
            protected override Dictionary<Type, Type> GetDataCreatedPair()
            {
                return new Dictionary<Type, Type>
                {
                    {typeof(MusicModule), typeof(MusicController)},
                    {typeof(LevelSwitchModule), typeof(LevelSwitchController)},
                    {typeof(TimerModule), typeof(TimerController)},
                    {typeof(GameEndModule), typeof(GameEndController)},
                    {typeof(PlayerStatModule), typeof(PlayerStatController)},
                    {typeof(MissionManagerData), typeof(MissionsManager)},
                    {typeof(DialogSystemModule), typeof(DialogSystemController)},
                    {typeof(UiModule), typeof(UiController)}
                };
            }
        }
    }
}
