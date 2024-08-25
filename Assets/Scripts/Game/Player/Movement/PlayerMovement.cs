using System;
using Api;
using Api.Inputs.InputUsers;
using Api.Navigation;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Player.Movement
{
    [RequireComponent(typeof(PlayerComponents))]
    public class PlayerMovement : MonoBehaviour, IInputUser
    {
        [SerializeField] private float distanceThreshold = 0.1f;
        [SerializeField] private LayerMask floorLayerMask;

        private IPlayerComponents _playerComponents;
        private IPlayerStats _playerStats;
        private IPlayerMovementStrategy _playerMovementStrategy;
        private INavigationSurfaceManager _navigationSurfaceManager;
        private SpriteRenderer _spriteRenderer;
        private Animator _animator;
        private NavMeshAgent _navMeshAgent;

        #region Animator Stuff
        
        private static readonly int IsWalking = Animator.StringToHash("isWalking");

        #endregion

        private void Update()
        {
            if (GameApi.InputManager.MoveInput) UseInput();
            if (_navMeshAgent.pathPending) return;
            if (!(_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance + distanceThreshold)) return;
            if (!_navMeshAgent.hasPath || _navMeshAgent.velocity.sqrMagnitude == 0f) OnDestinationReached();
        }

        private void Start()
        {
            _playerComponents = GetComponent<IPlayerComponents>();
            if (_playerComponents == null) return;
            
            _playerStats = _playerComponents.PlayerStats;
            _spriteRenderer = _playerComponents.PlayerSpriteRenderer;
            _animator = _playerComponents.PlayerAnimator;
            _navMeshAgent = _playerComponents.PlayerNavMeshAgent;
            _playerMovementStrategy = new PlayerMovementStrategyToMousePos();

            if (_navMeshAgent != null) InitializeNavMeshAgent();
        }

        private void InitializeNavMeshAgent()
        {
            _navMeshAgent.updateRotation = false;
            _navMeshAgent.updateUpAxis = false;
            _navMeshAgent.speed = MovementSpeed;
        }
        
        public void UseInput()
        {
            var targetPos = _playerMovementStrategy.DoMove();
            
            _navMeshAgent.SetDestination(targetPos);
            AnimatePlayerMovement(targetPos.x);
        }

        private void AnimatePlayerMovement(float xPos)
        {
            _animator.SetBool(IsWalking, true);
            _spriteRenderer.flipX = xPos < transform.position.x;
        }
        
        private void OnDestinationReached()
        {
            _animator.SetBool(IsWalking, false);
        }
        
        private float MovementSpeed => _playerStats.MovementSpeed;

        public IPlayerMovementStrategy MovementStrategy
        {
            get => _playerMovementStrategy;
            set => _playerMovementStrategy = value;
        }
    }
}