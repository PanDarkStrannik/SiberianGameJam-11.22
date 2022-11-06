using System;
using System.Collections.Generic;
using GameCore;

namespace GameClient
{
    public sealed class MissionsManager : BaseGameManagerModuleController<MissionManagerData>
    {
        private readonly Dictionary<MissionOwnerData, MissionData.MissionType> _ownersWhoStartMission = new Dictionary<MissionOwnerData, MissionData.MissionType>();
        private readonly List<MissionOwnerData> _ownersWhoMissionsFinished = new List<MissionOwnerData>();

        public event Action OnMissionsChanged;

        public override void Refresh()
        {
            _ownersWhoStartMission.Clear();
            _ownersWhoMissionsFinished.Clear();
        }

        public void OnMissionStart(MissionOwnerData owner, MissionData.MissionType missionType)
        {
            if (_ownersWhoStartMission.ContainsKey(owner) || _ownersWhoMissionsFinished.Contains(owner))
                return;
            _ownersWhoStartMission.Add(owner,missionType);
            OnMissionsChanged?.Invoke();
        }

        public void OnMissionFinished(MissionOwnerData owner)
        {
            if(!_ownersWhoStartMission.ContainsKey(owner))
                return;
            _ownersWhoStartMission.Remove(owner);
            _ownersWhoMissionsFinished.Add(owner);
            
            OnMissionsChanged?.Invoke();
        }

        public void OnMissionFailed(MissionOwnerData owner)
        {
            if (!_ownersWhoStartMission.ContainsKey(owner))
                return;
            _ownersWhoStartMission.Remove(owner);
            OnMissionsChanged?.Invoke();
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
