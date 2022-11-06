using System.Linq;
using GameCore;
using UnityEngine;

namespace GameClient
{
    public class DialogSystemController : BaseGameManagerModuleController<DialogSystemModule>
    {
        private GameManager _gameManager;
        private UiController _uiController;

        private DialogTree _currentDialog;

        private MissionOwnerData _missionOwner;
        private string _npcName = "";
        private Sprite _npcIcon;

        private bool _firstInit = true;

        protected override void InternalInitialize()
        {
            _gameManager = GameManager.Instance;
            _gameManager.SubscribeOnInitialize(OnGameManagerInitialized);
        }

        private void OnGameManagerInitialized()
        {
            _uiController = _gameManager.GetController<UiController>();
            var levelManager = _gameManager.GetController<LevelSwitchController>();
            levelManager.OnGameLevelLoaded += levels =>
            {
                if (!_firstInit || levels != LevelSwitchModule.GameLevels.Visa) return;
                var dialog = Data.Tree;
                _firstInit = false;
                StartDialog(dialog, Data.Estonian.NpcName, Data.Estonian.NpcSprite);
            };
        }

        public override void Refresh()
        {
            _firstInit = true;
        }

        public void StartDialog(MissionOwnerData owner)
        {
            _missionOwner = owner;
            _npcIcon = owner.NpcSprite;
            _npcName = owner.NpcName;
            StartDialog(owner.MainDialog, owner.NpcName, owner.NpcSprite);
        }

        public void StartDialog(DialogTree dialog, string npcName = "", Sprite npcIcon = null)
        {
            _currentDialog = dialog;
            Player.Instance.GetController<PlayerInputController>().Disable();
            _uiController.ShowDialog(dialog, Data.PlayerIcon, ContinueDialog, npcName, npcIcon);
        }

        private void ContinueDialog()
        {
            if (!_currentDialog.Answers.Any())
            {
                if (_currentDialog.StartMission != MissionData.MissionType.None && _missionOwner != null)
                {
                    _gameManager.GetController<MissionsManager>().MissionStart(_missionOwner, _currentDialog.StartMission);
                    EndDialog();
                }
                else
                {
                    EndDialog();
                }
            }
            else
            {
                if (_currentDialog.Answers.Count == 1)
                {
                    ChooseInDialog(_currentDialog.Answers.First());
                    return;
                }
                _uiController.ShowDialogWithAnswers(_currentDialog, Data.PlayerIcon, ChooseInDialog, _npcName, _npcIcon);
            }
                
        }

        private void ChooseInDialog(DialogTree chosenAnswer)
        {
            _currentDialog = chosenAnswer;
            _uiController.ShowDialog(_currentDialog, Data.PlayerIcon, ContinueDialog, _npcName, _npcIcon);
        }

        private void EndDialog()
        {
            Player.Instance.GetController<PlayerInputController>().Enable();
            _currentDialog = null;
            _missionOwner = null;
            _npcIcon = null;
            _npcName = "";
        }
    }
}
