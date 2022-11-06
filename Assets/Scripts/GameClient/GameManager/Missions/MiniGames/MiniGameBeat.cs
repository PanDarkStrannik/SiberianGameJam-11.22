using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
    public class MiniGameBeat : MiniGame
    {
        [SerializeField] private int _needBeatCount = 5;
        [SerializeField] private UnityEvent _unityEvent;
        protected override MissionData.MissionType MissionType => MissionData.MissionType.Beat;

        private int _beatCounter = 0;

        protected override void InteractStart()
        {
            base.InternalStart();
            _beatCounter++;
            if (_beatCounter < _needBeatCount) return;

            _unityEvent.Invoke();
            Missions.MissionFinished(OwnerData);
        }
    }
}
