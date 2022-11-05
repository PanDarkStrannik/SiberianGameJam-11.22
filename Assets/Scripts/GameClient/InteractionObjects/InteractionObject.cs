using UnityEngine;

namespace GameClient
{
    public abstract class InteractionObject : InteractionTrigger
    {
        public bool PlayerOnTrigger { get; private set; }

        protected Player InteractingPlayer { get; private set; }

        protected override void TriggerEnter(GameObject someGameObject)
        {
            if (!someGameObject.TryGetComponent<Player>(out var player)) return;

            PlayerOnTrigger = true;
            InteractingPlayer = player;
            player.GetController<PlayerInputController>().OnMouseClick += InteractStart;
        }

        protected override void TriggerExit(GameObject someGameObject)
        {
            if (!someGameObject.TryGetComponent<Player>(out var player)) return;

            PlayerOnTrigger = false;
            InteractingPlayer = null;
            player.GetController<PlayerInputController>().OnMouseClick -= InteractStart;
        }

        protected abstract void InteractStart();
    }
}
