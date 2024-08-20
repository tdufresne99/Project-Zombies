using System.Collections;
using Api.InteractableTool;
using UnityEngine;

namespace Game.InteractableTool
{
    public abstract class AbstractInteractableComponent : MonoBehaviour, IInteractableComponent
    {
        private const float LockOutCooldownTime = 0.2f;
        private bool _lockedOut = false;
        public void OnInteract()
        {
            if (_lockedOut) return;

            _lockedOut = true;
            StartCoroutine(LockOutCooldown());
            DoInteract();
        }

        protected abstract void DoInteract();

        private IEnumerator LockOutCooldown()
        {
            yield return new WaitForSecondsRealtime(LockOutCooldownTime);
            _lockedOut = false;
        }
    }
}