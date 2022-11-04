using System;
using Sirenix.OdinInspector;

namespace GameCore
{
    [Serializable, HideReferenceObjectPicker]
    public abstract class GameManagerModule
    {
        public string ModuleName => GetType().Name;
    }
}
