using System;
using System.Collections.Generic;
using GameCore.GameManager;

namespace GameClient
{
    [Serializable]
    public class GameManager : BaseGameManager<GameManager.GameManagerControllerFabric, GameManager>
    {
        public class GameManagerControllerFabric : BaseGameManageControllerFabric
        {
            protected override Dictionary<Type, Type> GetDataCreatedPair()
            {
                return new Dictionary<Type, Type>
                {
                    {typeof(MusicModule), typeof(MusicController)}
                };
            }
        }
    }
}
