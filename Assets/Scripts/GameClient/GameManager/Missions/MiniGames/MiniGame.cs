using UnityEngine;

namespace GameClient
{
    public abstract class MiniGame : InteractionObject
    {
        [SerializeField] private MissionOwnerData _ownerData;

        protected MissionOwnerData OwnerData => _ownerData;
        protected GameManager InitGameManager { get; private set; }
        protected MissionsManager Missions { get; private set; }

        protected PlayerStatController StatController { get; private set; }

        protected DialogSystemController DialogSystem { get; private set; }

        protected abstract MissionData.MissionType MissionType { get; }

        private void Start()
        {
            InitGameManager = GameManager.Instance;
            Missions = InitGameManager.GetController<MissionsManager>();
            StatController = InitGameManager.GetController<PlayerStatController>();
            DialogSystem = InitGameManager.GetController<DialogSystemController>();
            Missions.OnMissionsChanged += TryFinish;
            Missions.OnMissionFailed += MissionFailed; 
            TryFinish();
            InternalStart();
        }

        private void MissionFailed(MissionOwnerData failedOwner)
        {
            if (failedOwner != _ownerData)
                return;
            var missionData = GetMissionData();
            DialogSystem.StartDialog(missionData.DialogOnMissionFailed, _ownerData.NpcName, _ownerData.NpcSprite);
        }

        protected override void InteractStart()
        {
            if(!Missions.IsMissionStarted(OwnerData))
                return;
        }

        protected virtual void InternalStart()
        {
        }

        protected virtual void TryFinish()
        {
            if (!Missions.IsMissionFinished(_ownerData)) return;

            DamageStat();
            StartFinishDialog();
            Destroy(this);
        }

        private void StartFinishDialog()
        {
            var missionData = GetMissionData();
            DialogSystem.StartDialog(missionData.DialogOnMissionPassed, _ownerData.NpcName, _ownerData.NpcSprite);
        }

        protected void DamageStat()
        {
            var damageStat = GetMissionData().DamageStat;
            StatController.DamageStat(damageStat);
        }

        protected MissionData GetMissionData()
        {
            return OwnerData.GetMissionByType(MissionType);
        }

        private void OnDestroy()
        {
            Missions.OnMissionsChanged -= TryFinish;
            Missions.OnMissionFailed -= MissionFailed;
            InternalDestroy();
        }

        protected virtual void InternalDestroy()
        {

        }
    }
}
