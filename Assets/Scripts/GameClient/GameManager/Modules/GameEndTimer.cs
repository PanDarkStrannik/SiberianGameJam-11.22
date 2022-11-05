using System;
using GameCore;
using UnityEngine;

namespace GameClient
{
    [Serializable]
    public sealed class TimerModule : BaseGameManagerModule
    {
        [SerializeField] private int _timeToEndSec;
        [SerializeField] private int _timeStepMs;

        public int TimeToEnd => _timeToEndSec * MsInSec;

        public int TimeStep => _timeStepMs;

        private const int MsInSec = 1000;
    }
}
