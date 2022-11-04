using GameCore.Patterns;

namespace GameCore
{
    public abstract class BaseGameManagerModuleController<TData> : IDataDriver<TData>, IBaseGameManagerModuleController
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

    public interface IBaseGameManagerModuleController : IFabricCreated
    {
    }
}
