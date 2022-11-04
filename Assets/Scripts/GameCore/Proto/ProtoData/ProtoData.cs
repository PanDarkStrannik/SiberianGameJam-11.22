using System;
using System.Collections.Generic;
using GameCore.Utils;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace GameCore.Proto
{
    [Serializable]
    public class ProtoData
    {
        [OdinSerialize, ShowInInspector] private List<ProtoModule> _protoModules = new List<ProtoModule>();

        public bool HasModule(Type moduleType)
        {
            return _protoModules.HasElement(moduleType);
        }

        public bool TryGetModule<TProtoModule>(Type moduleType, out TProtoModule module) 
            where TProtoModule : ProtoModule
        {
            var hasModule = _protoModules.TryGet(moduleType, out var someModule);
            module = someModule as TProtoModule;
            return hasModule;
        }
    }
}