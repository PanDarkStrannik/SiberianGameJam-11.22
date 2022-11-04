using System;
using System.Collections.Generic;
using System.Linq;
using GameCore.Utils;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace GameCore.Proto
{
    [Serializable]
    public class ProtoData
    {
        [OdinSerialize, ShowInInspector, ListDrawerSettings(ListElementLabelName = nameof(BaseProtoModule.ModuleName))]
        private List<BaseProtoModule> _protoModules = new List<BaseProtoModule>();

        public IReadOnlyCollection<BaseProtoModule> ProtoModules => _protoModules.ToHashSet();

        public bool HasModule(Type moduleType)
        {
            return _protoModules.HasElement(moduleType);
        }

        public bool TryGetModule<TProtoModule>(Type moduleType, out TProtoModule module) 
            where TProtoModule : BaseProtoModule
        {
            var hasModule = _protoModules.TryGet(moduleType, out var someModule);
            module = someModule as TProtoModule;
            return hasModule;
        }
    }
}