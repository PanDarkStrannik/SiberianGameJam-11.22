using GameCore;
using UnityEngine;

namespace GameClient
{
    public class DialogSystemModule : BaseGameManagerModule
    {
        [SerializeField] private Sprite _playerIcon;

        public Sprite PlayerIcon => _playerIcon;
    }
}
