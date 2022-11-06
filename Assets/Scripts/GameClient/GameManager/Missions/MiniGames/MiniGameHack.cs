namespace GameClient
{
    public class MiniGameHack : MiniGame
    {
        protected override MissionData.MissionType MissionType => MissionData.MissionType.Hack;

        protected override void InteractStart()
        {
            base.InteractStart();
            var missionData = GetMissionData();
            GameManager.Instance.GetController<UiController>().ShowHackGame(missionData as HackMissionData, FinishGame);
        }

        private void FinishGame()
        {
            Missions.MissionFinished(OwnerData);
        }
    }
}
