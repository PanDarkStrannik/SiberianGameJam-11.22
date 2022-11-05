using System;
using GameCore;
using UnityEngine.SceneManagement;

namespace GameClient
{
    public class LevelSwitchController : BaseGameManagerModuleController<LevelSwitchModule>
    {
        public event Action<LevelSwitchModule.GameLevels> OnGameLevelLoaded;
        public event Action<LevelSwitchModule.UiLevels> OnUiLevelLoaded;

        protected override void InternalInitialize()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene loadedScene, LoadSceneMode arg1)
        {
            var gameLevel = Data.GetLevelById(loadedScene.buildIndex);
            var uiLevel = Data.GetUiLevelById(loadedScene.buildIndex);
            if (gameLevel == LevelSwitchModule.GameLevels.Unknown && uiLevel == LevelSwitchModule.UiLevels.Unknown 
                || gameLevel != LevelSwitchModule.GameLevels.Unknown && uiLevel != LevelSwitchModule.UiLevels.Unknown)
            {
                return;
            }
            if (gameLevel != LevelSwitchModule.GameLevels.Unknown)
                OnGameLevelLoaded?.Invoke(gameLevel);
            if (uiLevel != LevelSwitchModule.UiLevels.Unknown)
                OnUiLevelLoaded?.Invoke(uiLevel);
        }

        public void ChangeLevel(LevelSwitchModule.GameLevels gameLevel)
        {
            var buildIndex = Data.GetBuildId(gameLevel);
            ChangeLevel(buildIndex);
        }

        public void ChangeLevel(LevelSwitchModule.UiLevels uiLevel)
        {
            var buildIndex = Data.GetBuildId(uiLevel);
            ChangeLevel(buildIndex);
        }

        private static void ChangeLevel(int buildId)
        {
            if (buildId == -1)
                return;
            SceneManager.LoadScene(buildId);
        }
    }
}
