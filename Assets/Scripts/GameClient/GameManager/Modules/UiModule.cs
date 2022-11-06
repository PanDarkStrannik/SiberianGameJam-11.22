using GameCore;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameClient
{
    public class UiModule : BaseGameManagerModule
    {
        [SerializeField, AssetsOnly]
        private UiDialog _dialog;

        [SerializeField, AssetsOnly] 
        private UiDialogWithAnswers _dialogWithAnswers;

        public UiDialog Dialog => _dialog;
        public UiDialogWithAnswers DialogWithAnswers => _dialogWithAnswers;
    }
}
