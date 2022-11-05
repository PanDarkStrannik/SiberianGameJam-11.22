using System;
using System.Collections.Generic;
using GameCore;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace GameClient
{
    [Serializable]
    public sealed class LevelSwitchModule : BaseGameManagerModule
    {
        [OdinSerialize, ShowInInspector] private Dictionary<int, GameLevels> _buildIdLevelPair = new Dictionary<int, GameLevels>();
        [OdinSerialize, ShowInInspector] private Dictionary<int, UiLevels> _buildIdUiLevelPair = new Dictionary<int, UiLevels>();

        public GameLevels GetLevelById(int levelBuildId)
        {
            return !_buildIdLevelPair.TryGetValue(levelBuildId, out var gameLevel) ? GameLevels.Unknown : gameLevel;
        }

        public UiLevels GetUiLevelById(int levelBuildId)
        {
            return !_buildIdUiLevelPair.TryGetValue(levelBuildId, out var gameLevel) ? UiLevels.Unknown : gameLevel;
        }

        public int GetBuildId(GameLevels level)
        {
            foreach (var (key, value) in _buildIdLevelPair)
            {
                if (level == value)
                    return key;
            }

            return -1;
        }
        public int GetBuildId(UiLevels level)
        {
            foreach (var (key, value) in _buildIdUiLevelPair)
            {
                if (level == value)
                    return key;
            }

            return -1;
        }

        public enum GameLevels
        {
            Unknown = -1,
            Street,
            Photo,
            Bank,
            Mvd,
            Police,
            Medical,
            Visa
        }

        public enum UiLevels
        {
            Unknown = -1,
            MainMenu,
            WinMenu,
            LoseMenu
        }
    }
}
