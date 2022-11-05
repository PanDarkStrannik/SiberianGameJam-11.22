using System;
using GameCore;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameClient
{
    public sealed class PlayerInputController : BasePlayerModuleController<PlayerInputModule>
    {
        private PlayerInput.PlayerInput _playerInput;

        public bool IsActive { get; private set; }

        public event Action<bool> OnActiveChanged;
        public event Action<Vector2> OnMove;
        public event Action OnMouseClick; 

        protected override void InternalInitialize()
        {
            var player = Player.Instance;
            player.SubscribeOnInitialize(OnInitialize);
        }

        public override void Destroy()
        {
            _playerInput.Dispose();
        }

        private void OnInitialize()
        {
            _playerInput = new PlayerInput.PlayerInput();
            Enable();
        }

        public void Enable()
        {
            _playerInput.Enable();
            SubscribeOnEvents();
            IsActive = true;
            OnActiveChanged?.Invoke(IsActive);
        }

        public void Disable()
        {
            _playerInput.Disable();
            UnsubscribeOnEvents();
            IsActive = false;
            OnActiveChanged?.Invoke(IsActive);
        }

        private void SubscribeOnEvents()
        {
            var move = _playerInput.MainInput.Move;
            var mouseClick = _playerInput.MainInput.MouseClickLeft;

            move.started += MoveHandler;
            move.performed += MoveHandler;
            mouseClick.performed += MouseClick;
        }

        private void MoveHandler(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector2>();
            OnMove?.Invoke(direction);
        }

        private void MouseClick(InputAction.CallbackContext _)
        {
            OnMouseClick?.Invoke();
        }

        private void UnsubscribeOnEvents()
        {
            var move = _playerInput.MainInput.Move;
            var mouseClick = _playerInput.MainInput.MouseClickLeft;

            move.started -= MoveHandler;
            move.performed -= MoveHandler;
            mouseClick.performed -= MouseClick;
        }
    }
}
