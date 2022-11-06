using System;
using System.Collections.Generic;
using System.Linq;
using GameCore;

namespace GameClient
{
    public sealed class PlayerStatController : BaseGameManagerModuleController<PlayerStatModule>
    {
        private readonly Dictionary<PlayerStatModule.PlayerStats, StatDataController> _stats = new Dictionary<PlayerStatModule.PlayerStats, StatDataController>();

        private int _damageCallCount;
        private List<PlayerStatModule.PlayerStats> _statsDamageQueue = new List<PlayerStatModule.PlayerStats>();

        public IReadOnlyList<StatDataController> StatsDataControllers => _stats.Values.ToList();

        public event Action OnStatsUpdated; 

        protected override void InternalInitialize()
        {
            Refresh();
        }

        public override void Refresh()
        {
            _damageCallCount = 0;
            _stats.Clear();
            _statsDamageQueue.Clear();
            foreach (var (key, value) in Data.Stats)
            {
                var statController = new StatDataController(value, key);
                _stats.Add(key, statController);
            }
            OnStatsUpdated?.Invoke();
        }

        public void DamageStat(PlayerStatModule.PlayerStats stat)
        {
            _damageCallCount++;
            var controllerToDamage = _stats[stat];
            var repeatCount = _statsDamageQueue.Contains(stat) ? 1 : 0;
            for (var i = 0; i < _statsDamageQueue.Count - 1; i++)
            {
                var element1 = _statsDamageQueue[i];
                var element2 = _statsDamageQueue[i + 1];
                if (element1 == element2)
                {
                    repeatCount++;
                }
            }

            if (_statsDamageQueue.Count > 3)
            {
                _statsDamageQueue.RemoveAt(0);
            }
            _statsDamageQueue.Add(stat);

            var damageValue = Data.GetDamageFromTable(_damageCallCount, repeatCount);
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
