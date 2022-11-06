using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameClient
{
    public class MiniGameBribe : MiniGame
    {
        [SerializeField] private List<Camera> _cameras = new List<Camera>();
        protected override MissionData.MissionType MissionType => MissionData.MissionType.Bribe;

        protected override void InteractStart()
        {
            base.InteractStart();
            if (_cameras.Any(camera => camera.PlayerOnTrigger))
            {
                Missions.MissionFailed(OwnerData);
                return;
            }
            
            Missions.MissionFinished(OwnerData);
        }
    }
}
