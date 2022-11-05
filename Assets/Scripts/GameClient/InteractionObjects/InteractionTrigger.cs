using System;
using System.Linq;
using GameCore.Utils;
using UnityEngine;

namespace GameClient
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class InteractionTrigger : MonoBehaviour
    {
        private void Awake()
        {
            var triggers = gameObject.GetAllComponentsOfType<Collider2D>();
            var rigidBody = GetComponent<Rigidbody2D>();
            rigidBody.isKinematic = true;
            if (!triggers.Any())
                throw new SystemException($"No one collider on {gameObject.name}");
            foreach (var trigger in triggers)
                trigger.isTrigger = true;
        }

        

        private void OnTriggerEnter2D(Collider2D entered)
        {
            TriggerEnter(entered.attachedRigidbody.gameObject);
        }

        private void OnTriggerStay2D(Collider2D staying)
        {
            TriggerStay(staying.attachedRigidbody.gameObject);
        }

        private void OnTriggerExit2D(Collider2D exit)
        {
            TriggerExit(exit.attachedRigidbody.gameObject);
        }

        protected virtual void TriggerEnter(GameObject someGameObject)
        {

        }

        protected virtual void TriggerStay(GameObject someGameObject)
        {

        }

        protected virtual void TriggerExit(GameObject someGameObject)
        {

        }
    }
}
