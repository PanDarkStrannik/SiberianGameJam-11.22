using System;
using System.Collections.Generic;
using GameCore;

namespace GameClient
{
    public sealed class Player : BasePlayer<Player.PlayerControllerFabric, Player>
    {
        public class PlayerControllerFabric : BasePlayerControllerFabric
        {
            protected override Dictionary<Type, Type> GetDataCreatedPair()
            {
                return new Dictionary<Type, Type>
                {
                    {typeof(PlayerInputModule), typeof(PlayerInputController)},
                    {typeof(PlayerMovementModule), typeof(PlayerMovementController) },
                    {typeof(PlayerAnimatorModule), typeof(PlayerAnimatorController) },
                };
            }
        }
    }
}
