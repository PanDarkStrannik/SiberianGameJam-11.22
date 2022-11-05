using System;
using Sirenix.OdinInspector;

namespace GameClient
{
    [Serializable, HideReferenceObjectPicker, HideLabel]
    public class MissionData
    {
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
