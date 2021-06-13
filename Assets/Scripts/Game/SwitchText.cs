using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Player.Switch += Switch;
    }

    public void Switch()
    {
        GetComponent<Animator>().Play("switch");
        Debug.Log("stuf");
    }
}
