namespace GameClient
{
    public class MiniGameAgree : MiniGame
    {
        protected override MissionData.MissionType MissionType => MissionData.MissionType.Agree;

        protected override void TryFinish()
        {
            if (Missions.IsMissionStarted(OwnerData))
            {
                Missions.MissionFinished(OwnerData);
                return;
            }
            base.TryFinish();
        }
    }
}
