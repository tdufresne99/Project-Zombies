using System;
using Api.GameManager;
using UnityEngine;

namespace Game.GameManager
{
    public class GameManager : MonoBehaviour, IGameManager
    {
        [SerializeField] private Transform playerTransform;

        private Transform PlayerTransform
        {
            get => playerTransform;
            set
            {
                if (playerTransform == value) return;
                playerTransform = value;
                OnPlayerTransformChanged?.Invoke(value);
            }
        }
        
        public Transform GetPlayerTransform()
        {
            return playerTransform;
        }
        
        public event Action<Transform> OnPlayerTransformChanged;
    }
}