using System;
using System.Collections.Generic;
using GameCore;

namespace GameClient
{
    public sealed class MissionsManager : BaseGameManagerModuleController<MissionManagerData>
    {
        private readonly Dictionary<MissionOwnerData, MissionData.MissionType> _ownersWhoStartMission = new Dictionary<MissionOwnerData, MissionData.MissionType>();
        private readonly List<MissionOwnerData> _ownersWhoMissionsFinished = new List<MissionOwnerData>();

        public event Action<MissionOwnerData> OnMissionFailed; 
        public event Action OnMissionsChanged;

        private int _taskForWin = 5;

        public override void Refresh()
        {
            _ownersWhoStartMission.Clear();
            _ownersWhoMissionsFinished.Clear();
        }

        public void MissionStart(MissionOwnerData owner, MissionData.MissionType missionType)
        {
            if (_ownersWhoStartMission.ContainsKey(owner) || _ownersWhoMissionsFinished.Contains(owner))
                return;
            _ownersWhoStartMission.Add(owner,missionType);
            OnMissionsChanged?.Invoke();
        }

        public void MissionFinished(MissionOwnerData owner)
        {
            if(owner == null || !_ownersWhoStartMission.ContainsKey(owner))
                return;
            _ownersWhoStartMission.Remove(owner);
            _ownersWhoMissionsFinished.Add(owner);
            
            OnMissionsChanged?.Invoke();

            if (_ownersWhoMissionsFinished.Count > _taskForWin)
                GameManager.Instance.GetController<GameEndController>().Win();
        }

        public void MissionFailed(MissionOwnerData owner)
        {
            if (!_ownersWhoStartMission.ContainsKey(owner))
                return;
            _ownersWhoStartMission.Remove(owner);
            OnMissionFailed?.Invoke(owner);
            OnMissionsChanged?.Invoke();
        }

        public bool CanEstonianInteract()
        {
            return _ownersWhoStartMission.Count > _taskForWin - 1;
        }

        public bool IsMissionStarted(MissionOwnerData owner)
        {
            return _ownersWhoStartMission.ContainsKey(owner);
        }

        public bool IsMissionFinished(MissionOwnerData owner)
        {
            return _ownersWhoMissionsFinished.Contains(owner);
        }
    }
}
