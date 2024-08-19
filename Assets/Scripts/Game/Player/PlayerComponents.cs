using UnityEngine;
using UnityEngine.AI;

namespace Game.Player
{
    public class PlayerComponents : MonoBehaviour, IPlayerComponents
    {
        [SerializeField] private SpriteRenderer spriteRenderer; 
        [SerializeField] private Animator animator;
        [SerializeField] private Rigidbody2D rb; 
        [SerializeField] private NavMeshAgent navMeshAgent;
        [SerializeField] private PlayerStats playerStats;

        public SpriteRenderer PlayerSpriteRenderer => spriteRenderer;
        public Animator PlayerAnimator => animator;
        public Rigidbody2D PlayerRigidbody => rb;
        public NavMeshAgent PlayerNavMeshAgent => navMeshAgent;
        public IPlayerStats PlayerStats => playerStats;
    }
}