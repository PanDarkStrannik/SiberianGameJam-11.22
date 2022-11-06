using GameCore;
using UnityEngine;

namespace GameClient
{
    public class DialogSystemModule : BaseGameManagerModule
    {
        [SerializeField] private Sprite _playerIcon;

        [SerializeField] private DialogTree _tree;
        [SerializeField] private EstonianMissionOwner _estonian;

        public DialogTree Tree => _tree;
        public Sprite PlayerIcon => _playerIcon;

        public EstonianMissionOwner Estonian => _estonian;
    }
}
