using System.Collections;
using UnityEngine;
using Api;
using UnityEngine.AI;

namespace Game.Player
{
    [RequireComponent(typeof(PlayerComponents))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private LayerMask floorLayerMask;

        private IPlayerComponents _playerComponents;
        private IPlayerStats _playerStats;
        private Rigidbody2D _rb;
        private Animator _animator;
        private NavMeshAgent _navMeshAgent;
        private Vector2 _movementVector;
        private Camera _mainCamera;

        private Vector3 _lastPosition;
        private Vector3 _lastDirection;
        private Coroutine _lastMovementCall;

        #region Animator Stuff

        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private static readonly int Magnitude = Animator.StringToHash("Magnitude");
        private static readonly int LastHorizontal = Animator.StringToHash("LastHorizontal");
        private static readonly int LastVertical = Animator.StringToHash("LastVertical");

        #endregion

        private void Start()
        {
            _playerComponents = GetComponent<IPlayerComponents>();

            if (_playerComponents == null) return;
            _playerStats = _playerComponents.PlayerStats;
            _rb = _playerComponents.PlayerRigidbody;
            _animator = _playerComponents.PlayerAnimator;
            _navMeshAgent = _playerComponents.PlayerNavMeshAgent;

            _mainCamera = Camera.main;
            GameApi.InputManager.OnMouseLeftClick += OnPlayerMove;
        }

        // private void OnPlayerMove()
        // {
        //     var mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        //     mousePosition.z = 0;
        //     
        //     var hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, floorLayerMask);
        //
        //     if (hit.collider == null)
        //     {
        //         return;
        //     }
        //     
        //     var direction = (mousePosition - transform.position).normalized;
        //     if (_lastMovementCall != null)
        //     {
        //         StopCoroutine(_lastMovementCall);
        //         _rb.velocity = Vector2.zero;
        //     }
        //     _lastMovementCall = StartCoroutine(OnMove(mousePosition, direction));
        // }
        private void OnPlayerMove()
        {
            Vector2 mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            var targetPos = new Vector3(mousePos.x, mousePos.y, transform.position.z);
            _navMeshAgent.SetDestination(targetPos);
        }

        private IEnumerator OnMove(Vector3 targetPosition, Vector3 direction)
            {
                while (Vector2.Distance(_rb.position, targetPosition) > 0.1f)
                {
                    AnimatePlayerMovement(direction);
                    _rb.velocity = direction * MovementSpeed;
                    yield return new WaitForFixedUpdate();
                }
                _rb.velocity = Vector2.zero;
                AnimatePlayerMovement(Vector2.zero);
            }

            private void AnimatePlayerMovement(Vector3 direction)
            {
                _animator.SetFloat(Horizontal,direction.x );
                _animator.SetFloat(Vertical,direction.y );
                _animator.SetFloat(Magnitude,direction.magnitude);
                
                if (direction.magnitude == 0) return;
                _animator.SetFloat(LastHorizontal,direction.x);
                _animator.SetFloat(LastVertical,direction.y);
            }
            
            private float MovementSpeed => _playerStats.MovementSpeed;
        }
}