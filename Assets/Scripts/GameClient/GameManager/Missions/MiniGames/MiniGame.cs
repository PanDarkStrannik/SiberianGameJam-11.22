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

        protected UiController UiController { get; private set; }

        protected abstract MissionData.MissionType MissionType { get; }

        private void Start()
        {
            InitGameManager = GameManager.Instance;
            Missions = InitGameManager.GetController<MissionsManager>();
            StatController = InitGameManager.GetController<PlayerStatController>();
            UiController = InitGameManager.GetController<UiController>();
            Missions.OnMissionsChanged += TryFinish;
            TryFinish();
            InternalStart();
        }

        protected override void InteractStart()
        {
        }

        protected virtual void InternalStart()
        {
        }

        protected virtual void TryFinish()
        {
            if (!Missions.IsMissionFinished(_ownerData)) return;

            DamageStat();
            Destroy(this);
        }

        protected void DamageStat()
        {
            var damageStat = OwnerData.GetMissionByType(MissionType).DamageStat;
            StatController.DamageStat(damageStat);
        }

        private void OnDestroy()
        {
            Missions.OnMissionsChanged -= TryFinish;
            InternalDestroy();
        }

        protected virtual void InternalDestroy()
        {

        }
    }
}
