using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector2 dir = Vector2.right;
    public int startCount;
    public List<BodySprite> blueSprites;
    public List<BodySprite> redSprites;
    public GameObject bodypartPrefab;
    public List<Bodypart> body;

    // Use this for initialization
    void Start () 
    {
        if (startCount % 2 != 0)
            startCount++;
        
        InvokeRepeating("Move", 0.3f, 0.3f);

        for (int i = 0; i < startCount; i++)
        {
            var obj = Instantiate(bodypartPrefab, 
                    new Vector3(transform.position.x - i, transform.position.y, transform.position.z), 
                    Quaternion.identity, this.transform);
            
            if (i < (startCount / 2))
                obj.GetComponent<Bodypart>().blue = true;
            else
                obj.GetComponent<Bodypart>().blue = false;

            body.Add(obj.GetComponent<Bodypart>());
        }
    }
   
    // Update is called once per frame
    void Update () 
    {
        CheckInput();

        ChangeBodySprites();
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

    void ChangeBodySprites()
    {
        for (int i = 0; i < body.Count; i++)
        {
            body[i].gameObject.GetComponent<SpriteRenderer>().sprite = GetSprite(i);
        }
    }

    Sprite GetSprite(int bodypartInt)
    {
        Vector3 overDir = Vector3.zero;
        Vector3 underDir = Vector3.zero;

        try
        {
            overDir = body[bodypartInt + 1].transform.position - body[bodypartInt].transform.position;
        }
        catch
        {
            return body[bodypartInt].gameObject.GetComponent<SpriteRenderer>().sprite;
        }

        try
        {
            underDir = body[bodypartInt - 1].transform.position - body[bodypartInt].transform.position;
        }
        catch
        {
            return body[bodypartInt].gameObject.GetComponent<SpriteRenderer>().sprite;
        }

        Debug.Log("Overdir is right = " + (overDir == Vector3.right));
        Debug.Log("UnderDir is right = " + (underDir == Vector3.right));

        string spriteName = null;

        if ((overDir == Vector3.right && underDir == Vector3.left) || (overDir == Vector3.left && underDir == Vector3.right))
            spriteName = "Horizontal";
        if ((overDir == Vector3.up && underDir == Vector3.down) || (overDir == Vector3.down && underDir == Vector3.up))
            spriteName = "Vertical";
        else
            spriteName = "HUH";

        if (body[bodypartInt].blue)
            return blueSprites.First(bodypart => bodypart.name == spriteName).sprite;
        else
            return redSprites.First(bodypart => bodypart.name == spriteName).sprite;
    }

    void CheckInput()
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

    [System.Serializable]
    public class BodySprite
    {
        public string name;
        public Sprite sprite;
    }
}
