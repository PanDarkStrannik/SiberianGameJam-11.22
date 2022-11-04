using System;
using GameCore;
using UnityEngine;

namespace GameClient
{
    [Serializable]
    public sealed class PlayerAnimatorModule : BasePlayerModule
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private MoveAnimParameters _moveAnim = new MoveAnimParameters();

        public Animator Animator => _animator;
        public MoveAnimParameters MoveAnim => _moveAnim;

        [Serializable]
        public class MoveAnimParameters
        {
            [SerializeField] private string _upDownParameter;
            [SerializeField] private string _leftRightParameter;

            public string UpDown => _upDownParameter;
            public string LeftRight => _leftRightParameter;
        }
    }
}
