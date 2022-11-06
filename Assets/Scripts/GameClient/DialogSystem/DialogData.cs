using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameClient
{
    [HideReferenceObjectPicker]
    public class DialogTree
    {
        [SerializeField] private string _dialogName;
        [SerializeField, HideLabel] private DialogData _dialog = new DialogData();
        [SerializeField, HideIf(nameof(AnswersExist))]
        private MissionData.MissionType _startMission;

        [SerializeField, ListDrawerSettings(ListElementLabelName = nameof(_dialogName))] 
        private List<DialogTree> _answers = new List<DialogTree>();

        public DialogData Dialog => _dialog;

        public MissionData.MissionType StartMission => AnswersExist() ? MissionData.MissionType.None : _startMission;

        public IReadOnlyList<DialogTree> Answers => _answers;

        private bool AnswersExist()
        {
            return _answers.Any();
        }
    }

    [Serializable, HideReferenceObjectPicker]
    public class DialogData
    {
        [SerializeField, TextArea] private string _npcSay;
        [SerializeField, TextArea] private string _playerSay;

        public string NpcSay => _npcSay;
        public string PlayerSay => _playerSay;
    }
}
