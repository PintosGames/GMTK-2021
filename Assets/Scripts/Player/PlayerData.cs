using UnityEngine;

namespace Pintos.Player
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player Data", order = 0)]
    public class PlayerData : ScriptableObject
    {
        public float movementSpeed = 10;
        public int startingLength;
    }
}