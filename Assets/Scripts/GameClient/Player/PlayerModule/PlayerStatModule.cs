using System;
using System.Collections.Generic;
using GameCore;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameClient
{
    [Serializable]
    public sealed class PlayerStatModule : BasePlayerModule
    {
        [SerializeField] private Dictionary<PlayerStats, StatData> _stats = new Dictionary<PlayerStats, StatData>();

        public Dictionary<PlayerStats, StatData> Stats => _stats;

        [Serializable, HideReferenceObjectPicker]
        public class StatData : ICloneable
        {
            [SerializeField, ReadOnly] private int _startValue = 100;
            [SerializeField, OnValueChanged(nameof(OnReverseChanged))] private bool _fromMaxToMin = true;

            public int StartValue => _startValue;
            public bool FromMaxToMin => _fromMaxToMin;

            private void OnReverseChanged()
            {
                _startValue = FromMaxToMin ? 100 : 0;
            }

            public object Clone()
            {
                return new StatData
                {
                    _startValue = StartValue,
                    _fromMaxToMin = FromMaxToMin
                };
            }
        }
        public enum PlayerStats
        {
            Criminal,
            Health,
            Mental,
            Money
        }
    }
}
