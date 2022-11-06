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

        protected override void InternalInitialize()
        {
            _gameManager = GameManager.Instance;
            _gameManager.SubscribeOnInitialize(OnGameManagerInitialized);
        }

        private void OnGameManagerInitialized()
        {
            _uiController = _gameManager.GetController<UiController>();
        }

        public void StartDialog(MissionOwnerData owner)
        {
            StartDialog(owner.MainDialog, owner.NpcName, owner.NpcSprite);
        }

        public void StartDialog(DialogTree dialog, string npcName = "", Sprite npcIcon = null)
        {
            _currentDialog = dialog;
            Player.Instance.GetController<PlayerInputController>().Disable();
            _uiController.ShowDialog(dialog.Dialog, Data.PlayerIcon, ContinueDialog, npcName, npcIcon);
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
                else if (_currentDialog.StartMission == MissionData.MissionType.None)
                {
                    EndDialog();
                }
            }
            else
            {
                _uiController.ShowDialogWithAnswers(_currentDialog, Data.PlayerIcon, ChooseInDialog, _npcName, _npcIcon);
            }
                
        }

        private void ChooseInDialog(DialogTree chosenAnswer)
        {
            _currentDialog = chosenAnswer;
            _uiController.ShowDialog(_currentDialog.Dialog, Data.PlayerIcon, ContinueDialog, _npcName, _npcIcon);
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
