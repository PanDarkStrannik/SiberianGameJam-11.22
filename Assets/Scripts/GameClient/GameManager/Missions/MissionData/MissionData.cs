using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameClient
{
    [Serializable, HideReferenceObjectPicker]
    public abstract class MissionData
    {
        [SerializeField] 
        private DialogTree _dialogOnMissionPassed = new DialogTree();

        [SerializeField, HideIf(nameof(CanNotFailed))] 
        private DialogTree _dialogOnMissionFailed = new DialogTree();

        public DialogTree DialogOnMissionPassed => _dialogOnMissionPassed;
        public DialogTree DialogOnMissionFailed => _dialogOnMissionFailed;

        public abstract bool CanNotFailed { get; }
        public abstract MissionType MissionUid { get; }

        public abstract PlayerStatModule.PlayerStats DamageStat { get; }

        public enum MissionType
        {
            None,
            Agree,
            Beat,
            Hack,
            Bribe
        }
    }
}
