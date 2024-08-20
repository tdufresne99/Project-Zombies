using System;
using System.Collections;
using Api;
using Api.InteractableTool;
using UnityEngine;

namespace Game.InteractableItems
{
    public abstract class AbstractInteractableComponent : MonoBehaviour, IInteractableComponent
    {
        [SerializeField] private float interactableDistance = 4f;
        private const float LockOutCooldownTime = 0.2f;
        private bool _onLockOutCooldown;
        private bool CanInteract => !_onLockOutCooldown && InRange();

        public void OnInteract()
        {
            if (!CanInteract) return;

            _onLockOutCooldown = true;
            StartCoroutine(LockOutCooldown());
            DoInteract();
        }
        protected abstract void DoInteract();
        private void OnMouseEnter()
        {
            DoMouseEnter();
        }
        protected abstract void DoMouseEnter();
        
        private void OnMouseExit()
        {
            DoMouseExit();
        }
        protected abstract void DoMouseExit();


        private bool InRange()
        {
            var playerTransform = GameApi.GameManager.GetPlayerTransform().position;
            return Vector2.Distance(playerTransform, transform.position) < interactableDistance;
        }
        private IEnumerator LockOutCooldown()
        {
            yield return new WaitForSecondsRealtime(LockOutCooldownTime);
            _onLockOutCooldown = false;
        }
    }
}