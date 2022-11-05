using Sirenix.OdinInspector;
using UnityEngine;

namespace GameClient
{
    [CreateAssetMenu(fileName = "New LocationData", menuName = "Balance/LocationData")]
    public class LocationData : SerializedScriptableObject
    {
        [SerializeField, TabGroup("NPC")]
        private Sprite _npcSprite;
        [SerializeField, TabGroup("NPC")] 
        private string _npcName;

        [SerializeField, TabGroup("Dialog Tree"), HideLabel]
        private DialogTree _dialog = new DialogTree();

        [SerializeField, TabGroup("Missions")]
        private MissionData _missionData = new MissionData();

        public Sprite NpcSprite => _npcSprite;
        public string NpcName => _npcName;
        public DialogTree Dialog => _dialog;
        public MissionData MissionData => _missionData;
    }
}
