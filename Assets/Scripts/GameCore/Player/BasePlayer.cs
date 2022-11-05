using System.Collections.Generic;
using System.Linq;
using GameCore.Patterns;
using GameCore.Utils;
using UnityEngine;

namespace GameCore
{
    public abstract class BasePlayer<T, TV> : MonoSingleton<TV>
        where T : BasePlayer<T, TV>.BasePlayerControllerFabric, new()
        where TV : MonoSingleton<TV>
    {
        [SerializeField] private PlayerData _playerData;

        public IReadOnlyList<IBasePlayerModuleController> Controllers { get; private set; } = new List<IBasePlayerModuleController>();

        private T _fabric = new T();

        private OnceCallEvent _onInitialize = new OnceCallEvent();

        protected sealed override void Initialize()
        {
            Controllers = _playerData.Modules.ToHashSet().Select(e => _fabric.Create(e)).ToList();
            InternalInitialize();
            _onInitialize.Invoke();
        }

        protected virtual void InternalInitialize()
        {

        }

        public void SubscribeOnInitialize(OnceCallEvent.Subscriber subscriber)
        {
            _onInitialize.Subscribe(subscriber);
        }

        public TController GetController<TController>()
            where TController : IBasePlayerModuleController
        {
            Controllers.TryGet(out TController element);
            return element;
        }

        public abstract class BasePlayerControllerFabric : InitializerFabric<IBasePlayerModuleController, BasePlayerModule>
        {

        }
    }
}
