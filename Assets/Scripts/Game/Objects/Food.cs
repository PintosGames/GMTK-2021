using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pintos.Game.Objects
{
    public delegate void FoodPickedUp();
    public class Food : MonoBehaviour
    {
        public static event FoodPickedUp FoodPickedUp;

        private void OnTriggerEnter2D(Collider2D other) 
        {
            Debug.Log("Collision");
            FoodPickedUp();
            FindObjectOfType<Player>().ate = true;
            Destroy(this.gameObject);
        }
    }
}
