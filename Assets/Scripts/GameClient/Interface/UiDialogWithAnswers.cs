using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameClient
{
    public class UiDialogWithAnswers : MonoBehaviour
    {
        [SerializeField] 
        private UiDialogPanel _dialogPanel;

        [SerializeField] private Transform _parentTransform;

        [SerializeField, AssetsOnly] private AnswerButton _buttonPrefab;
        public void Initialize(DialogTree answersTree, Sprite playerDialogIcon, Action<DialogTree> onDialogContinue, string npcName = "", Sprite npcIcon = null)
        {
            _dialogPanel.Initialize(answersTree, playerDialogIcon, npcName, npcIcon);
            foreach (var answer in answersTree.Answers)
            {
                var button = Instantiate(_buttonPrefab.gameObject, _parentTransform);
                var answerButton = button.GetComponent<AnswerButton>();
                answerButton.Initialize(answer, onDialogContinue);
                answerButton.OnClick += AnswerButtonOnClick;
            }
        }

        private void AnswerButtonOnClick()
        {
            Destroy(gameObject);
        }
    }
}
