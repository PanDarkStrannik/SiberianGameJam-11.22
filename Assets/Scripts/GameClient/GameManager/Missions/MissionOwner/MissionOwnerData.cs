using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameClient
{
    [CreateAssetMenu(fileName = "New Mission Owner Data", menuName = "Balance/MissionOwnerData")]
    public class MissionOwnerData : SerializedScriptableObject
    {
        [SerializeField, TabGroup("NpcData")]
        private Sprite _npcSprite;

        [SerializeField, TabGroup("NpcData")]
        private string _npcName;

        [SerializeField, HideLabel, TabGroup("MainDialog")]
        private DialogTree _mainDialog = new DialogTree();

        [SerializeField, HideLabel, TabGroup("Missions")]
        private List<MissionData> _missions = new List<MissionData>
        {
            new AgreeMissionData(),
            new BeatMissionData(),
            new BribeMissionData(),
            new HackMissionData()
        };


        public Sprite NpcSprite => _npcSprite;
        public string NpcName => _npcName;

        public DialogTree MainDialog => _mainDialog;
        public IReadOnlyList<MissionData> Missions => _missions;

        public MissionData GetMissionByType(MissionData.MissionType missionType)
        {
            return _missions.First(mission => mission.MissionUid == missionType);
        }

    }
}
