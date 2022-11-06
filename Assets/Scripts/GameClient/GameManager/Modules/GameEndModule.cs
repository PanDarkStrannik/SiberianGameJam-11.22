using System.Collections.Generic;
using GameCore;
using UnityEngine;

namespace GameClient
{
    public class GameEndModule : BaseGameManagerModule
    {
        [SerializeField] public string _winText;
        [SerializeField] public string _voenkomText;
        [SerializeField] private Dictionary<PlayerStatModule.PlayerStats, string> _looseByStat;

        public string GetStringByLosedStat(PlayerStatModule.PlayerStats key)
        {
            return _looseByStat[key];
        }
    }
}
