using System;
using GameCore;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GameClient
{
    public sealed class UiController : BaseGameManagerModuleController<UiModule>
    {
        private Canvas _targetCanvas;

        protected override void InternalInitialize()
        {
            _targetCanvas = GameManager.Instance.TargetCanvas;
        }

        public void ShowHackGame(HackMissionData hackMission, Action onGameFinished)
        {

        }

        public void ShowDialog(DialogData dialog, Sprite playerDialogIcon, Action onDialogContinue, string npcName = "", Sprite npcIcon = null)
        {
            CreateWindow(Data.Dialog);
        }

        public void ShowDialogWithAnswers(DialogTree answersTree, Sprite playerDialogIcon, Action<DialogTree> onDialogContinue, string npcName = "", Sprite npcIcon = null)
        {
           CreateWindow(Data.DialogWithAnswers);
        }


        private void CreateWindow(Component mono)
        {
            Object.Instantiate(mono.gameObject, _targetCanvas.transform);
        }
    }
}
