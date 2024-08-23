using System;
using System.Collections;
using Api.InteractableComponents;
using Game.Player;
using UnityEngine;

namespace Game.InteractableComponents
{
    public class InteractableRangeDetector : MonoBehaviour
    {
        private readonly float _autoDestroyTimer = 5.0f;
        private CircleCollider2D _detectionCollider;
        private IInteractable _interactable;

        private void OnDestroy()
        {
            StopAllCoroutines();
            Destroy(_detectionCollider);
            OnCollisionDetected = null;
        }

        public void Initialize(float interactDistance)
        {
            _detectionCollider = gameObject.AddComponent<CircleCollider2D>();
            _detectionCollider.isTrigger = true;
            _detectionCollider.radius = interactDistance;

            StartCoroutine(AutoDestroy());
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other) return;
            if (!other.gameObject.TryGetComponent<IPlayer>(out var interactable)) return;
            OnCollisionDetected?.Invoke();
            Destroy(this);
        }

        private IEnumerator AutoDestroy()
        {
            yield return new WaitForSeconds(_autoDestroyTimer);
            Destroy(this);
        }

        public event Action OnCollisionDetected;
    }
}