using UnityEngine;

namespace Game.Player
{
    public class PlayerStats : MonoBehaviour, IPlayerStats
    {
        [Range(0.0f, 10.0f)]
        [SerializeField] private float movementSpeed = 5.0f;
        public float MovementSpeed
        {
            get => movementSpeed;
            set => movementSpeed = value;
        }

        [SerializeField] private int intelligence = 0;
        public int Intelligence
        {
            get => intelligence;
            set => intelligence = value;
        }
        
        [SerializeField] private int creativity = 0;
        public int Creativity
        {
            get => creativity;
            set => creativity = value;
        }
        
        [SerializeField] private int strength = 0;
        public int Strength
        {
            get => strength;
            set => strength = value;
        }
        
        [SerializeField] private int dexterity = 0;
        public int Dexterity
        {
            get => dexterity;
            set => dexterity = value;
        }
        
        // intuition
        // leadership
        // charisma
    }
}