namespace GameClient
{
    public class BeatMissionData : MissionData
    {
        public override bool CanNotFailed => true;
        public override MissionType MissionUid => MissionType.Beat;

        public override PlayerStatModule.PlayerStats DamageStat => PlayerStatModule.PlayerStats.Health;
    }
}
