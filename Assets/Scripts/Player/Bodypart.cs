using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pintos.Game.Objects;

public class Bodypart : MonoBehaviour
{
    public bool blue;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Food>() != null)
        {
            FindObjectOfType<Player>().ate = true;
        }
        else
            FindObjectOfType<Player>().GameOver();
    }

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("Misc");
    }
}
