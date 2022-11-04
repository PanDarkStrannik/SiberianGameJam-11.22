using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameCore.Patterns
{
    public class MonoSingleton : MonoBehaviour
    {
        private static MonoSingleton _instance;
        public static MonoSingleton Instance
        {
            get
            {
                var instances = FindObjectsOfType<MonoSingleton>();
                CleanSingletons(instances);

                if (_instance != null && instances.Contains(_instance))
                {
                    return _instance;
                }

                var emptyGo = new GameObject(nameof(MonoSingleton), typeof(MonoSingleton));
                _instance = emptyGo.GetComponent<MonoSingleton>();

                return _instance;
            }
        }


        private static void CleanSingletons(IEnumerable<MonoSingleton> singletons)
        {
            if (!singletons.Any()) return;
            foreach (var singleton in singletons.ToArray())
            {
                if (singleton != _instance)
                    Destroy(singleton);
            }
        }
    }
}