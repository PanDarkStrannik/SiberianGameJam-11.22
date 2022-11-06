using Sirenix.OdinInspector;
using UnityEngine;

namespace GameClient
{
    [CreateAssetMenu(fileName = "Estonian mission owner", menuName = "Balance/EstonianMissionOwnerData")]
    public class EstonianMissionOwner : MissionOwnerData
    {
        [SerializeField, TabGroup("Estonian Dialog"), HideLabel]
        private DialogTree _estonianDialog = new DialogTree();

        public DialogTree EstonianDialog => _estonianDialog;
    }
}
