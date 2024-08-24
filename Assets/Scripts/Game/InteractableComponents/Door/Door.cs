using System;
using Api.InteractableComponents;
using Api.InteractableComponents.Door;
using Game.InteractableComponents.Lever;
using UnityEngine;

namespace Game.InteractableComponents.Door
{
    public class Door : MonoBehaviour, IDoor
    {
        private static readonly int Opened = Animator.StringToHash("isOpened");
        [SerializeField] private Game.InteractableComponents.Lever.Lever lever;
        private Animator _animator;
        private BoxCollider2D _collider;
        private bool _isOpened;

        private void OnDestroy()
        {
            lever.OnInteractableStateChanged -= OnStateChanged;
        }

        private void Start()
        {
            IsOpened = false;
            lever.OnInteractableStateChanged += OnStateChanged;
            _animator = GetComponent<Animator>();
            _collider = GetComponent<BoxCollider2D>();
        }

        public void OnStateChanged(InteractableState state)
        {
            IsOpened = state switch
            {
                InteractableState.Active => true,
                InteractableState.Inactive => false,
                _ => IsOpened
            };
        }
        
        private void OpenStateChanged(bool value)
        {
            _animator.SetBool(Opened, value);
            _collider.enabled = !value;
        }

        private bool IsOpened
        {
            get => _isOpened;
            set
            {
                if(_isOpened == value) return;
                _isOpened = value;
                OpenStateChanged(value);
            }
        }
    }
}