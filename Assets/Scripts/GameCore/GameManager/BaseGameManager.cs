using System;
using System.Collections.Generic;
using System.Linq;
using GameCore.Patterns;
using GameCore.Utils;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameCore.GameManager
{
    [Serializable]
    public abstract class BaseGameManager<T> : MonoSingleton
        where T: BaseGameManager<T>.BaseGameManageControllerFabric, new()
    {
        [SerializeReference, ListDrawerSettings(ListElementLabelName = nameof(GameManagerModule.ModuleName))]
        private List<GameManagerModule> _modules = new List<GameManagerModule>();

        private T _fabric = new T();

        private readonly OnceCallEvent _onInitialize = new OnceCallEvent();

        public IReadOnlyList<IGameManagerModuleController> Controllers { get; private set; } = new List<IGameManagerModuleController>();

        
        private void Awake()
        {
            Initialize();
        }

        protected virtual void Initialize()
        {
            Controllers = _modules.ToHashSet().Select(module => _fabric.Create(module)).ToList();
            _onInitialize.Invoke();
        }

        public void SubscribeOnInitialize(OnceCallEvent.Subscriber subscriber)
        {
            _onInitialize.Subscribe(subscriber);
        }

        public TModuleController GetModule<TModuleController>() 
            where TModuleController : IGameManagerModuleController
        {
            Controllers.TryGet<IGameManagerModuleController, TModuleController>(out var controller);
            return controller;
        }

        public abstract class BaseGameManageControllerFabric : InitializerFabric<IGameManagerModuleController, GameManagerModule>
        {
        }
    }
}
