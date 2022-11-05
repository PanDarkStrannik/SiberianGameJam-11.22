using System;
using System.Linq;
using GameCore;
using GameCore.Utils;
using UnityEngine;

namespace GameClient
{
    public sealed class PlayerAnimatorController : BasePlayerModuleController<PlayerAnimatorModule>
    {
        private Animator _animator;
        private PlayerAnimatorModule.MoveAnimParameters _moveAnim;
        private Player _player;

        protected override void InternalInitialize()
        {
            _player = Player.Instance;
            _player.SubscribeOnInitialize(OnPlayerInit);
        }

        private void OnPlayerInit()
        {
            _moveAnim = Data.MoveAnim;
            _animator = _player.gameObject.GetAllComponentsOfType<Animator>().First();
        }

        public void AnimateMove(Vector2 direction)
        {
            if (_animator == null || _animator.runtimeAnimatorController == null)
                return;
            var xDirection = (int)Math.Clamp(direction.x, -1, 1);
            var yDirection = (int)Math.Clamp(direction.y, -1, 1);

            if (yDirection == 0)
            {
                _animator.SetInteger(_moveAnim.LeftRight, xDirection);
            }
            else
            {
                _animator.SetInteger(_moveAnim.UpDown, yDirection);
            }
        }
    }
}
