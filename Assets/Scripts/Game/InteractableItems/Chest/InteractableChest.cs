using Game.InteractableTool;
using UnityEngine;

namespace Game.InteractableItems.Chest
{
    public class InteractableChest : AbstractInteractableComponent
    {
        private static readonly int Opened = Animator.StringToHash("opened");
        private Animator _animator;
        private bool _isOpened;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        protected override void DoInteract()
        {
            _isOpened = !_isOpened;
            _animator.SetBool(Opened, _isOpened);
        }
    }
}