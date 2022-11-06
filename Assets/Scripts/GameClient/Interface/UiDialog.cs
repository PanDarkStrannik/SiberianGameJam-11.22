using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameClient
{
    public class UiDialog : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private UiDialogPanel _dialogPanel;

        private Action _onDialogContinue;

        public void Initialize(DialogTree dialog, Sprite playerDialogIcon, Action onDialogContinue, string npcName = "", Sprite npcIcon = null)
        {
            _onDialogContinue = onDialogContinue;
            _dialogPanel.Initialize(dialog, playerDialogIcon, npcName, npcIcon);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Destroy(gameObject);
            _onDialogContinue?.Invoke();
        }
    }
}
