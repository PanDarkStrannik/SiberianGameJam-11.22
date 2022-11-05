using System;
using GameCore;
using UnityEngine;

namespace GameClient
{
    [Serializable]
    public sealed class PlayerMovementModule : BasePlayerModule
    {
        [SerializeField] private int _playerSpeed = 1;

        public int PlayerSpeed => _playerSpeed;
    }
}
