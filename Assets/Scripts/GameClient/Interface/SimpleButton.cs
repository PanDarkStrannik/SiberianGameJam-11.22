using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
    [RequireComponent(typeof(Button))]
    public class SimpleButton : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _buttonText;

        protected TextMeshProUGUI ButtonText => _buttonText;
        public event Action OnClick;
        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            InternalButtonClick();
            OnClick?.Invoke();
        }

        protected virtual void InternalButtonClick()
        {

        }
    }
}
