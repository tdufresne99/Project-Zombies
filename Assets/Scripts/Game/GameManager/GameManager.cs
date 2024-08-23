using Api.GameManager;
using UnityEngine;

namespace Game.GameManager
{
    public class GameManager : MonoBehaviour, IGameManager
    {
        [SerializeField] private Transform playerTransform;
        public Transform PlayerTransform
        {
            get => playerTransform;
            set => playerTransform = value; 
        }

        public Vector2 PlayerPosition => PlayerTransform.position;
    }
}