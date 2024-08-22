using Api;
using Api.Inputs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Inputs
{
    public class InputManager : MonoBehaviour, IInputManager
    {
        public static InputManager Instance { get; private set; }

        public bool MoveInput { get; private set; }
        public bool InteractInput { get; private set; }
        public bool AttackInput { get; private set; }
        public bool DashInput { get; private set; }
        public bool MenuOpenCloseInput { get; private set; }

        private PlayerInput _playerInput;

        private InputAction _moveAction;
        private InputAction _interactAction;
        private InputAction _attackAction;
        private InputAction _dashAction;
        private InputAction _menuOpenCloseAction;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else Destroy(gameObject);

            _playerInput = GetComponent<PlayerInput>();

            _playerInput.camera = GameApi.MainCamera;

            SetupInputActions();
        }
        
        private void Update()
        {
            UpdateInputs();
        }
        
        private void SetupInputActions()
        {
            _moveAction = _playerInput.actions["Move"];
            _interactAction = _playerInput.actions["Interact"];
            _attackAction = _playerInput.actions["Attack"];
            _dashAction = _playerInput.actions["Dash"];
            _menuOpenCloseAction = _playerInput.actions["MenuOpenClose"];
        }

        private void UpdateInputs()
        {
            MoveInput = _moveAction.WasPressedThisFrame();
            InteractInput = _interactAction.WasPressedThisFrame();
            AttackInput = _attackAction.WasPressedThisFrame();
            DashInput = _dashAction.WasPressedThisFrame();
            MenuOpenCloseInput = _menuOpenCloseAction.WasPressedThisFrame();
        }
    }
}