using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
    [RequireComponent(typeof(Button))]
    public class SimpleButton : MonoBehaviour
    {
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
