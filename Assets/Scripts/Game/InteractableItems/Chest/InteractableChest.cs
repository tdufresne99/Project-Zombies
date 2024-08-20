using UnityEngine;

namespace Game.InteractableItems.Chest
{
    public class InteractableChest : AbstractInteractableComponent
    {
        [SerializeField] private Color highLightColor;
        private static readonly int Opened = Animator.StringToHash("opened");
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;
        private bool _isOpened;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        protected override void DoInteract()
        {
            _isOpened = !_isOpened;
            _animator.SetBool(Opened, _isOpened);
        }

        protected override void DoMouseEnter()
        {
            _spriteRenderer.color = highLightColor;
        }
        
        protected override void DoMouseExit()
        {
            _spriteRenderer.color = Color.white;
        }
    }
}