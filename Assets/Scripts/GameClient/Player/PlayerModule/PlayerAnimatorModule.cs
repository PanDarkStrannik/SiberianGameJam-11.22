using System;
using GameCore;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameClient
{
    [Serializable]
    public sealed class PlayerAnimatorModule : BasePlayerModule
    {
        [SerializeField] private MoveAnimParameters _moveAnim = new MoveAnimParameters();
        public MoveAnimParameters MoveAnim => _moveAnim;

        [Serializable, HideReferenceObjectPicker]
        public class MoveAnimParameters
        {
            [SerializeField] private string _upDownParameter;
            [SerializeField] private string _leftRightParameter;

            public string UpDown => _upDownParameter;
            public string LeftRight => _leftRightParameter;
        }
    }
}
