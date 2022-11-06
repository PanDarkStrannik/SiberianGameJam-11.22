using System;
using System.Collections.Generic;
using GameCore;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameClient
{
    [Serializable]
    public sealed class PlayerStatModule : BaseGameManagerModule
    {
        [SerializeField] private Dictionary<PlayerStats, StatData> _stats = new Dictionary<PlayerStats, StatData>();
        [SerializeField] private List<StatDamageLir> _statDamageTable = new List<StatDamageLir>();

        public Dictionary<PlayerStats, StatData> Stats => _stats;

        public int GetDamageFromTable(int actionsCount, int repeatActionsCount)
        {
            var damageLir = _statDamageTable[actionsCount - 1];
            return repeatActionsCount <= 2 ? damageLir.DamageOneTwoAction : damageLir.DamageThreeFourthAction;
        }

        [Serializable, HideReferenceObjectPicker]
        public class StatData
        {
            [SerializeField, ReadOnly] private int _startValue = 100;
            [SerializeField, OnValueChanged(nameof(OnReverseChanged))] private bool _fromMaxToMin = true;

            public int StartValue => _startValue;
            public bool FromMaxToMin => _fromMaxToMin;

            private void OnReverseChanged()
            {
                _startValue = FromMaxToMin ? 100 : 0;
            }
        }

        [Serializable, HideReferenceObjectPicker]
        private class StatDamageLir
        {
            [SerializeField] private int _damageOneTwoAction = 0;
            [SerializeField] private int _damageThreeFourthAction = 0;

            public int DamageOneTwoAction => _damageOneTwoAction;
            public int DamageThreeFourthAction => _damageThreeFourthAction;
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
