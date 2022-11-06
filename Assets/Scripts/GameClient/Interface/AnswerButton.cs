using System;
using System.Linq;

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
            var treeForMissionType = tree;
            var missionType = MissionData.MissionType.None;
            while (treeForMissionType.Answers.Any() && missionType  == MissionData.MissionType.None)
            {
                treeForMissionType = treeForMissionType.Answers.First();
                missionType = treeForMissionType.StartMission;
            }
            switch (missionType)
            {
                case MissionData.MissionType.Agree:
                    ButtonText.text = "Согласиться";
                    break;
                case MissionData.MissionType.Beat:
                    ButtonText.text = "Избить";
                    break;
                case MissionData.MissionType.Hack:
                    ButtonText.text = "Взломать";
                    break;
                case MissionData.MissionType.Bribe:
                    ButtonText.text = "Подкупить";
                    break;
            }
        }

        protected override void InternalButtonClick()
        {
            base.InternalButtonClick();
            _answer.Invoke(_tree);
        }
    }
}
