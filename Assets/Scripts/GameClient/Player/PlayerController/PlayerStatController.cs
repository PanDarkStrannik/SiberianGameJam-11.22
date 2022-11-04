using System;
using System.Collections.Generic;
using System.Linq;
using GameCore;

namespace GameClient
{
    public sealed class PlayerStatController : BasePlayerModuleController<PlayerStatModule>
    {
        private readonly Dictionary<PlayerStatModule.PlayerStats, StatDataController> _stats = new Dictionary<PlayerStatModule.PlayerStats, StatDataController>();

        public IReadOnlyList<StatDataController> StatsDataControllers => _stats.Values.ToList();

        protected override void InternalInitialize()
        {
            foreach (var (key, value) in Data.Stats)
            {
                var statController = new StatDataController(value, key);
                _stats.Add(key, statController);
            }
        }

        public void ChangeStat(PlayerStatModule.PlayerStats stat, int damageValue)
        {
            var controllerToDamage = _stats[stat];
            controllerToDamage.DamageStat(damageValue);
        }

        public class StatDataController
        {
            public PlayerStatModule.PlayerStats StatType { get; private set; }
            public bool FromMaxToMin { get; private set; }
            public int StartValue { get; private set; }
            public int Value { get; private set; }

            public event Action<StatDataController> OnStatChanged;
            public event Action<StatDataController> OnStatValueOppositeStart;

            public StatDataController(PlayerStatModule.StatData statData, PlayerStatModule.PlayerStats statType)
            {
                FromMaxToMin = statData.FromMaxToMin;
                Value = statData.StartValue;
                StatType = statType;
            }

            public void DamageStat(int damage)
            {
                var beforeChanged = Value;

                if (FromMaxToMin)
                {
                    Value -= damage;
                }
                else
                {
                    Value += damage;
                }

                if (beforeChanged == Value)
                {
                    OnStatChanged?.Invoke(this);
                }

                if(Value <= 0 || Value >= 100)
                {
                    OnStatValueOppositeStart?.Invoke(this);
                }
            }
        }
    }
}
