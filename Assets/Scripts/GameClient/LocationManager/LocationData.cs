using Sirenix.OdinInspector;
using UnityEngine;

namespace GameClient
{
    [CreateAssetMenu(fileName = "New LocationData", menuName = "Balance/LocationData")]
    public class LocationData : SerializedScriptableObject
    {
        [SerializeField, TabGroup("Dialog Tree"), HideLabel]
        private DialogTree _dialog = new DialogTree();

        [SerializeField, TabGroup("Missions")]
        private MissionData _missionData = new MissionData();
    }
}
