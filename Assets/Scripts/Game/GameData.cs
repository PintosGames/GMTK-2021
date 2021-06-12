using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pintos.Game
{
    [CreateAssetMenu(fileName = "GameData", menuName = "Data/Game Data", order = 0)]
    public class GameData : ScriptableObject 
    {
        public GameObject foodPrefab;

        public Borders borders;

        public void Spawn(GameObject prefab)
        {
            var openSpawn = false;
            Vector3 spawn = new Vector3();

            while (!openSpawn)
            {
                // x position between left & right border
                int x = (int)Random.Range(borders.left.x, borders.right.x);
                // y position between top & bottom border
                int y = (int)Random.Range(borders.bottom.y, borders.top.y);

                spawn = new Vector3(x, y, 0);

                if (!Physics.CheckSphere(spawn, 1))
                {
                    openSpawn = true;
                }
            }

            // Instantiate the food at (x, y)
            Instantiate(prefab, spawn, Quaternion.identity);
        }

        [System.Serializable]
        public class Borders
        {
            public Vector2 top;
            public Vector2 bottom;
            public Vector2 left;
            public Vector2 right;
        }
    }
}