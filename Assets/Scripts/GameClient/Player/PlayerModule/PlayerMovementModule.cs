using System;
using GameCore;
using UnityEngine;

namespace GameClient
{
    [Serializable]
    public sealed class PlayerMovementModule : BasePlayerModule
    {
        [SerializeField] private Rigidbody2D _body; 
        [SerializeField] private int _playerSpeed = 1;

        public int PlayerSpeed => _playerSpeed;
        public Rigidbody2D Body => _body;
    }
}
