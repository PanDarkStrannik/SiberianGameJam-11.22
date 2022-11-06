using UnityEngine;

namespace GameClient
{
    public class MissionOwnerInstance : InteractionObject
    {
        [SerializeField] private MissionOwnerData _ownerData;

        private MissionsManager _missionsManager;

        private void Start()
        {
            _missionsManager = GameManager.Instance.GetController<MissionsManager>();
            _missionsManager.OnMissionsChanged += TryFinish;
            TryFinish();
        }

        protected override void InteractStart()
        {
            if (_missionsManager.IsMissionStarted(_ownerData))
                return;
            GameManager.Instance.GetController<DialogSystemController>().StartDialog(_ownerData);
        }

        private void TryFinish()
        {
            if (!_missionsManager.IsMissionFinished(_ownerData)) return;

            Destroy(this);
        }
    }
}
