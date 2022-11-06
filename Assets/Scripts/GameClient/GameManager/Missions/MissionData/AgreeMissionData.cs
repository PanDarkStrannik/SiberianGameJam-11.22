namespace GameClient
{
    public class AgreeMissionData : MissionData
    {
        public override bool CanNotFailed => true;
        public override MissionType MissionUid => MissionType.Agree;

        public override PlayerStatModule.PlayerStats DamageStat => PlayerStatModule.PlayerStats.Mental;
    }
}
