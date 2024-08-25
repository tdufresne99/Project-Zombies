using Api;
using Api.InteractableComponents;
using Api.InteractableComponents.Door;
using NavMeshPlus.Components;
using UnityEngine;

namespace Game.InteractableComponents.Door
{
    public class Door : MonoBehaviour, IDoor
    {
        private static readonly int Opened = Animator.StringToHash("isOpened");
        [SerializeField] private Game.InteractableComponents.Lever.Lever lever;
        private NavMeshModifier[] _navMeshModifiers;
        private Animator _animator;
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
            _navMeshModifiers = GetComponentsInChildren<NavMeshModifier>();
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
            var walkableValue = value ? 0 : 1;
            foreach (var modifier in _navMeshModifiers)
            {
                modifier.area = walkableValue;
            }
            GameApi.NavigationSurfaceManager.BakeSurface();
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