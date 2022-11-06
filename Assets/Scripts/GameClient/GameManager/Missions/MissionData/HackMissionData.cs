using UnityEngine;

namespace GameClient
{
    public class HackMissionData : MissionData
    {
        [SerializeField] private string _code;
        public override bool CanNotFailed => true;
        public override MissionType MissionUid => MissionType.Hack;
        public override PlayerStatModule.PlayerStats DamageStat => PlayerStatModule.PlayerStats.Criminal;
    }
}
