using UnityEngine;

namespace Game.InteractableComponents.Chest
{
    public class InteractableChest : AbstractInteractable
    {
        private static readonly int Opened = Animator.StringToHash("opened");
        private Animator _animator;
        private bool _isOpened;

        protected override void DoStart()
        {
            base.DoStart();
            _animator = GetComponent<Animator>();
        }

        protected override void DoInteract()
        {
            _isOpened = !_isOpened;
            _animator.SetBool(Opened, _isOpened);
        }
    }
}