using System.Collections;
using Api;
using Api.InteractableComponents;
using UnityEngine;

namespace Game.InteractableComponents
{
    public abstract class AbstractInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField] protected Color highlightColor = new (0.802f, 0.757f, 0.624f, 1f);
        [SerializeField] protected Color normalColor = Color.white;
        [SerializeField] protected bool useHighlight = true;
        [SerializeField] private float interactableDistance = 0.5f;
        [SerializeField] protected float lockOutCooldownTime = 0.2f;
        protected SpriteRenderer spriteRenderer;
        private InteractableRangeDetector _rangeDetector;
        
        private bool _onLockOutCooldown;

        public float InteractableDistance
        {
            get => interactableDistance;
            set => interactableDistance = value;
        }

        private void Start()
        {
            DoStart();
        }

        protected virtual void DoStart()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private bool CanInteract()
        {
            return !_onLockOutCooldown && InRange();
        }
        
        private bool InRange()
        {
            var playerPosition = GameApi.GameManager.PlayerPosition;
            return Vector2.Distance(playerPosition, transform.position) < interactableDistance;
        }
        
        private IEnumerator LockOutCooldown()
        {
            _onLockOutCooldown = true;
            yield return new WaitForSecondsRealtime(lockOutCooldownTime);
            _onLockOutCooldown = false;
        }

        public void OnInteract()
        {
            if (_onLockOutCooldown) return;
            var rangeDetectorIsNull = _rangeDetector == null;
            if (!InRange())
            {
                if (!rangeDetectorIsNull) Destroy(_rangeDetector);
                _rangeDetector = gameObject.AddComponent<InteractableRangeDetector>();
                _rangeDetector.OnCollisionDetected += OnDoInteract;
                _rangeDetector.Initialize(interactableDistance);
                return;
            }
            if (!rangeDetectorIsNull) Destroy(_rangeDetector);
            OnDoInteract();
        }

        private void OnDoInteract()
        {
            StartCoroutine(LockOutCooldown());
            DoInteract();
        }
        
        protected abstract void DoInteract();

        #region MouseEvents
        private void OnMouseEnter()
        {
            DoMouseEnter();
        }
        protected virtual void DoMouseEnter()
        {
            if (useHighlight) ChangeSpriteColor(highlightColor);
        }
        
        private void OnMouseExit()
        {
            DoMouseExit();
        }
        protected virtual void DoMouseExit()
        {
            if (useHighlight) ChangeSpriteColor(normalColor);
        }
        #endregion

        protected void ChangeSpriteColor(Color color)
        {
            spriteRenderer.color = color;
        }
    }
}