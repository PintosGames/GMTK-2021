using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bodypart : MonoBehaviour
{
    public bool blue;

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("Misc");
    }
}
