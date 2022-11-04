using System;
using System.Collections.Generic;
using GameCore.Proto;

namespace GameClient
{
    public class ProtoInstance : BaseProtoInstance<ProtoInstance.ProtoControllerFabric>
    {
        public class ProtoControllerFabric : BaseProtoControllerFabric
        {
            protected override Dictionary<Type, Type> GetDataCreatedPair()
            {
                return new Dictionary<Type, Type>
                {

                };
            }
        }
    }
}
