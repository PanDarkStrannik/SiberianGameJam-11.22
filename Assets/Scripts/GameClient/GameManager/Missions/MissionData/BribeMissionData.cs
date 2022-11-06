namespace GameClient
{
    public class BribeMissionData : MissionData
    {
        public override bool CanNotFailed => false;
        public override MissionType MissionUid => MissionType.Bribe;

        public override PlayerStatModule.PlayerStats DamageStat => PlayerStatModule.PlayerStats.Money;
    }
}