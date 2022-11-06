using Sirenix.OdinInspector;
using UnityEngine;

namespace GameClient
{
    public class UiDialogPanel : MonoBehaviour
    {
        [SerializeField, AssetsOnly] private UiDialogLir _lir;

        public void Initialize(DialogTree answer, Sprite playerDialogIcon, string npcName = "", Sprite npcIcon = null)
        {
            var lir = Instantiate(_lir.gameObject, transform).GetComponent<UiDialogLir>();

            if (answer.Dialog.NpcSay == "")
            {
                lir.Initialize(null, "", "NONE");
            }
            else
            {
                lir.Initialize(npcIcon, answer.Dialog.NpcSay, npcName);
            }

            lir = Instantiate(_lir.gameObject, transform).GetComponent<UiDialogLir>();
            if (answer.Dialog.PlayerSay == "")
            {
                lir.Initialize(null, "", "NONE");
            }
            else
            {
                lir.Initialize(playerDialogIcon, answer.Dialog.PlayerSay);
            }
        }
    }
}
