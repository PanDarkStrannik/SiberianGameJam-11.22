using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Proto
{
    public class ProtoData
    {
        [SerializeField] private List<ProtoModule> _protoModules = new List<ProtoModule>();

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