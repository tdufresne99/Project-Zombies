using UnityEngine;
using UnityEngine.AI;

namespace Game.Player
{
    public class PlayerComponents : MonoBehaviour, IPlayerComponents
    {
        [SerializeField] private Rigidbody2D playerRigidbody; 
        [SerializeField] private Animator playerAnimator;
        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private NavMeshAgent playerNavMeshAgent;

        public Rigidbody2D PlayerRigidbody => playerRigidbody;
        public Animator PlayerAnimator => playerAnimator;
        public NavMeshAgent PlayerNavMeshAgent => playerNavMeshAgent;
        public IPlayerStats PlayerStats => playerStats;
    }
}