using UnityEngine;

namespace GameClient
{
    public class HackMissionData : MissionData
    {
        [SerializeField, TextArea]
        private string _paperText;
        [SerializeField] private string _code;

        public string PaperText => _paperText;
        public string Code => _code;
        public override bool CanNotFailed => true;
        public override MissionType MissionUid => MissionType.Hack;
        public override PlayerStatModule.PlayerStats DamageStat => PlayerStatModule.PlayerStats.Criminal;
    }
}
