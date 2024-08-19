using UnityEngine;
using UnityEngine.AI;

namespace Game.Player
{
    public interface IPlayerComponents
    {
        public SpriteRenderer PlayerSpriteRenderer { get; }
        public Rigidbody2D PlayerRigidbody { get; }
        public Animator PlayerAnimator { get; }
        public NavMeshAgent PlayerNavMeshAgent { get; }
        public IPlayerStats PlayerStats { get; }
    }
}