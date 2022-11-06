namespace GameClient
{
    public class MiniGameHack : MiniGame
    {
        protected override MissionData.MissionType MissionType => MissionData.MissionType.Hack;

        protected override void InteractStart()
        {
            base.InteractStart();
            FinishGame();
        }

        private void FinishGame()
        {
            Missions.MissionFinished(OwnerData);
        }
    }
}
