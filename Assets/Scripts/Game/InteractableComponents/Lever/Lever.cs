using System;
using Api.InteractableComponents;
using Api.InteractableComponents.Lever;
using UnityEngine;

namespace Game.InteractableComponents.Lever
{
    public class Lever : AbstractInteractable, ILever
    {
        private static readonly int IsActive = Animator.StringToHash("isActive");
        private InteractableState _state;
        private Animator _animator;

        public InteractableState State
        {
            get => _state;
            set
            {
                if (_state == value) return;
                _state = value;
                InteractableStateChanged(value);
            } 
        }

        protected override void DoStart()
        {
            base.DoStart();
            _animator = GetComponent<Animator>();
            State = InteractableState.Inactive;
        }

        protected override void DoInteract()
        {
            State = _state switch
            {
                InteractableState.Inactive => InteractableState.Active,
                InteractableState.Active => InteractableState.Inactive,
                _ => State
            };
        }

        private void InteractableStateChanged(InteractableState state)
        {
            switch (state)
            {
                case InteractableState.Active:
                    _animator.SetBool(IsActive, true);
                    break;
                case InteractableState.Inactive:
                    _animator.SetBool(IsActive, false);
                    break;
            }
            OnInteractableStateChanged?.Invoke(state);
        }

        public event Action<InteractableState> OnInteractableStateChanged;
    }
}