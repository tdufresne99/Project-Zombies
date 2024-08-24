using UnityEngine;

namespace Game.Player.Movement
{
    public interface IPlayerMovementStrategy
    {
        Vector3 DoMove();
    }
}