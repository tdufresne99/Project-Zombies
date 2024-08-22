using System;
using System.Collections;
using Api;
using Api.InteractableComponents;
using Game.Inputs;
using UnityEngine;

namespace Game.InteractableItems
{
    public abstract class AbstractInteractable : MonoBehaviour, IInteractable
    {
        private float _interactableDistance = 1f;
        private const float LockOutCooldownTime = 0.2f;
        private bool _onLockOutCooldown;
        private bool CanInteract => !_onLockOutCooldown && InRange();

        public bool OnInteract()
        {
            if (!CanInteract) return false;

            _onLockOutCooldown = true;
            StartCoroutine(LockOutCooldown());
            DoInteract();
            return true;
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
            return Vector2.Distance(playerTransform, transform.position) < _interactableDistance;
        }
        private IEnumerator LockOutCooldown()
        {
            yield return new WaitForSecondsRealtime(LockOutCooldownTime);
            _onLockOutCooldown = false;
        }
    }
}