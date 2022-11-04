using GameCore;
using UnityEngine;

namespace GameClient
{
    public sealed class PlayerMovementController : BasePlayerModuleController<PlayerMovementModule>
    {
        private int Speed => Data.PlayerSpeed;
        private Rigidbody2D Body => Data.Body;
        private Player PlayerInstance => Player.Instance;
        private PlayerInputController _inputController;

        protected override void InternalInitialize()
        {
            PlayerInstance.SubscribeOnInitialize(OnPlayerInitialized);
        }

        private void OnPlayerInitialized()
        {
            _inputController = PlayerInstance.GetController<PlayerInputController>();
            _inputController.OnMove += Move;
        }

        private void Move(Vector2 direction)
        {
            Body.velocity = direction * Speed;
        }
    }
}
