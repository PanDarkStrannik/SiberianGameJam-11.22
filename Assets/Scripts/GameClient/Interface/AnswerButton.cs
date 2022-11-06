using System;
using UnityEngine;

namespace GameClient
{
    public class AnswerButton : SimpleButton
    {
        private Action<DialogTree> _answer;
        private DialogTree _tree;
        public void Initialize(DialogTree tree, Action<DialogTree> answer)
        {
            _tree = tree;
            _answer = answer;
            var missionData = _tree.StartMission;
            
        }

        protected override void InternalButtonClick()
        {
            base.InternalButtonClick();
            _answer.Invoke(_tree);
        }
    }
}
