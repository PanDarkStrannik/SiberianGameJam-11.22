using UnityEngine;

namespace GameClient
{
    public class AgreeMissionData : MissionData
    {
        [SerializeField, TextArea]
        private string _textOnBlack;

        public string TextOnBlack => _textOnBlack;

        public override bool CanNotFailed => true;
        public override MissionType MissionUid => MissionType.Agree;

        public override PlayerStatModule.PlayerStats DamageStat => PlayerStatModule.PlayerStats.Mental;
    }
}
