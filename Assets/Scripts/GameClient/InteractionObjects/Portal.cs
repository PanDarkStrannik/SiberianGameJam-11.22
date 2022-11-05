using UnityEngine;

namespace GameClient
{
    public class Portal : InteractionObject
    {
        [SerializeField] private LevelSwitchModule.GameLevels _teleportOn;
        protected override void InteractStart()
        {
            var switchController = GameManager.Instance.GetController<LevelSwitchController>();
            switchController.ChangeLevel(_teleportOn);
        }
    }
}
