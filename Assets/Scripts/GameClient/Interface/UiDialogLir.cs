using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
    public class UiDialogLir : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private TextMeshProUGUI _name;

        public void Initialize(Sprite icon, string text, string name = "")
        {
            if (text == "")
            {
                _icon.gameObject.SetActive(false);
                _text.gameObject.SetActive(false);
                _name.gameObject.SetActive(false);
                return;
            }
            if (icon == null)
                _icon.gameObject.SetActive(false);
            if (name == "")
                _name.gameObject.SetActive(false);
            _icon.sprite = icon;
            _text.text = text;
            _name.text = name;
        }
    }
}
