using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector2 dir = Vector2.right;
    public int startCount;
    public GameObject bodypartPrefab;
    public List<Bodypart> body;

    // Use this for initialization
    void Start () 
    {
        InvokeRepeating("Move", 0.3f, 0.3f);

        for (int i = 0; i < startCount; i++)
        {
            var obj = Instantiate(bodypartPrefab, 
                    new Vector3(transform.position.x - i, transform.position.y, transform.position.z), 
                    Quaternion.identity, this.transform);
            
            body.Add(obj.GetComponent<Bodypart>());
        }
    }
   
    // Update is called once per frame
    void Update () 
    {
        // Move in a new Direction?
        if (Input.GetKey(KeyCode.RightArrow))
            dir = Vector2.right;
        else if (Input.GetKey(KeyCode.DownArrow))
            dir = -Vector2.up;    // '-up' means 'down'
        else if (Input.GetKey(KeyCode.LeftArrow))
            dir = -Vector2.right; // '-right' means 'left'
        else if (Input.GetKey(KeyCode.UpArrow))
            dir = Vector2.up;
        else dir = Vector2.zero;
    }
   
    void Move() 
    {
        var v = body.First().transform.position;

        body.First().transform.Translate(dir);

        if (dir != Vector2.zero)
        {
            body.Last().transform.position = v;
            body.Last().blue = !body.Last().blue;

            body.Insert(1, body.Last());
            body.RemoveAt(body.Count - 1);
        }
    }
}
