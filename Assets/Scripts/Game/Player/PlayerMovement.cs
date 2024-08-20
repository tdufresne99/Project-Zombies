using System;
using System.Collections;
using UnityEngine;
using Api;
using UnityEngine.AI;

namespace Game.Player
{
    [RequireComponent(typeof(PlayerComponents))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float distanceThreshold = 0.1f;
        [SerializeField] private LayerMask floorLayerMask;

        private IPlayerComponents _playerComponents;
        private IPlayerStats _playerStats;
        private SpriteRenderer _spriteRenderer;
        private Animator _animator;
        private NavMeshAgent _navMeshAgent;
        private Camera _mainCamera;

        #region Animator Stuff
        
        private static readonly int IsWalking = Animator.StringToHash("isWalking");

        #endregion

        private void Update()
        {
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

            if (_navMeshAgent != null) InitializeNavMeshAgent();
            
            _mainCamera = GameApi.MainCamera;
            GameApi.InputManager.OnMouseLeftClick += OnPlayerMove;
        }

        private void InitializeNavMeshAgent()
        {
            _navMeshAgent.updateRotation = false;
            _navMeshAgent.updateUpAxis = false;
            _navMeshAgent.speed = MovementSpeed;
        }
        private void OnPlayerMove()
        {
            Vector2 mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            var targetPos = new Vector3(mousePos.x, mousePos.y, 0);
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
    }
}