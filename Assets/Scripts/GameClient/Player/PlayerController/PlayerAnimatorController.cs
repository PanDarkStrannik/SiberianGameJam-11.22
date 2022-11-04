using System;
using GameCore;
using UnityEngine;

namespace GameClient
{
    public sealed class PlayerAnimatorController : BasePlayerModuleController<PlayerAnimatorModule>
    {
        private Animator _animator;
        private PlayerAnimatorModule.MoveAnimParameters _moveAnim;
        protected override void InternalInitialize()
        {
            _animator = Data.Animator;
            _moveAnim = Data.MoveAnim;
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
