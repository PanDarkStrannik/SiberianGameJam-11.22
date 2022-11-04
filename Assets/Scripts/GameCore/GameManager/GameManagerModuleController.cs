using GameCore.Patterns;

namespace GameCore
{
    public abstract class GameManagerModuleController<TData> : IDataDriver<TData>, IGameManagerModuleController
        where TData : GameManagerModule
    {
        public TData Data { get; private set; }
        public void Initialize(TData data)
        {
            Data = data;
            InternalInitialize();
        }

        public void Initialize(object data)
        {
            Initialize(data as TData);
        }

        protected virtual void InternalInitialize()
        {

        }
    }

    public interface IGameManagerModuleController : IFabricCreated
    {
    }
}
