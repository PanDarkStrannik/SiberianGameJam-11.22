using GameCore;
using UnityEngine;

namespace GameClient
{
    public sealed class PlayerMovementController : BasePlayerModuleController<PlayerMovementModule>
    {
        private int _speed;
        private Rigidbody2D _body;
        private Player _playerInstance;
        private PlayerInputController _inputController;
        private PlayerAnimatorController _animator;

        protected override void InternalInitialize()
        {
            _speed = Data.PlayerSpeed;
            _body = Data.Body;
            _playerInstance = Player.Instance;
            _playerInstance.SubscribeOnInitialize(OnPlayerInitialized);
        }

        private void OnPlayerInitialized()
        {
            _inputController = _playerInstance.GetController<PlayerInputController>();
            _animator = _playerInstance.GetController<PlayerAnimatorController>();
            _inputController.OnActiveChanged += InputActiveChanged;
            InputActiveChanged(_inputController.IsActive);
        }

        private void InputActiveChanged(bool isActive)
        {
            if (isActive)
            {
                _inputController.OnMove += Move;
            }
            else
            {
                _inputController.OnMove -= Move;
                Move(Vector2.zero);
            }
        }

        private void Move(Vector2 direction)
        {
            _body.velocity = direction * _speed;
            _animator.AnimateMove(_body.velocity);
        }
    }
}