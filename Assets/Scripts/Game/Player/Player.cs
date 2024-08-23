using UnityEngine;

namespace Game.Player
{
    public class Player : MonoBehaviour, IPlayer
    {
        public IPlayerStats PlayerStats { get; set; }
    }
}