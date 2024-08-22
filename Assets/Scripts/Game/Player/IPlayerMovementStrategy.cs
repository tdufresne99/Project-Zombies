using UnityEngine;

namespace Game.Player
{
    public interface IPlayerMovementStrategy
    {
        Vector3 DoMove();
    }
}