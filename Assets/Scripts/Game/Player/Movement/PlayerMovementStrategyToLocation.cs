using Api;
using UnityEngine;

namespace Game.Player.Movement
{
    public class PlayerMovementStrategyToMousePos : IPlayerMovementStrategy
    {
        public Vector3 DoMove()
        {
            Vector2 mousePos = GameApi.MainCamera.ScreenToWorldPoint(Input.mousePosition);
            return new Vector3(mousePos.x, mousePos.y, 0);
        }
    }
}