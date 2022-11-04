using System;
using GameCore.Patterns;

namespace GameCore
{
    public abstract class BaseGameManageControllerFabric : InitializerFabric<IGameManagerModuleController, GameManagerModule>
    {
        protected override IGameManagerModuleController InternalCreate(GameManagerModule data, Type wantCreate)
        {
            var moduleController = Activator.CreateInstance(wantCreate) as IGameManagerModuleController;
            moduleController?.Initialize(data);
            return moduleController;
        }
    }
}
