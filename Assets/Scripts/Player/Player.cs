using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Player : MonoBehaviour
{
    public float lastSwitch;
    public float switchCooldown;
    public bool isControllingBlue = true;
    Vector2 dir = Vector2.right;
    public int startCount;
    public List<BodySprite> blueSprites;
    public List<BodySprite> redSprites;
    public GameObject bodypartPrefab;
    public List<Bodypart> body;
    public bool ate;

    private ScoreCounter counter;

    // Use this for initialization
    void Start () 
    {
        counter = FindObjectOfType<ScoreCounter>();

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

        lastSwitch = Time.realtimeSinceStartup;
    }
   
    // Update is called once per frame
    void Update () 
    {
        CheckInput();

        Debug.Log(Time.realtimeSinceStartup);
        if (Time.realtimeSinceStartup > lastSwitch + switchCooldown)
        {
            body.Reverse();
            lastSwitch = Time.realtimeSinceStartup;
            isControllingBlue = !isControllingBlue;
        }
    }
   
    void Move() 
    {
        var v = body.First().transform.position;

        body.First().transform.Translate(dir);

        if (dir != Vector2.zero)
        {
            // Ate something? Then insert new Element into gap
            if (ate) 
            {
                // Load Prefab into the world
                GameObject g = (GameObject)Instantiate(bodypartPrefab,
                                                    v,
                                                    Quaternion.identity,
                                                    this.transform);

                g.GetComponent<Bodypart>().blue = isControllingBlue;
                // Keep track of it in our tail list
                body.Insert(1, g.GetComponent<Bodypart>());

                // Reset the flag
                ate = false;
                
                ChangeBodySprites();
            }
            else
            {
                body.Last().transform.position = v;
                body.Last().blue = !body.Last().blue;
                body.Insert(1, body.Last());
                body.RemoveAt(body.Count - 1);
            }
        }
        
        ChangeBodySprites();

        counter.CountBodyParts();
        
        if (counter.blueParts == 0 || counter.redParts == 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
        string spriteName = null;
        Vector3 overDir = Vector3.zero;
        Vector3 underDir = Vector3.zero;

        try
        {
            overDir = body[bodypartInt + 1].transform.position - body[bodypartInt].transform.position;
        }
        catch(ArgumentOutOfRangeException)
        {
            underDir = body[bodypartInt - 1].transform.position - body[bodypartInt].transform.position;

            if (underDir == Vector3.down)
                spriteName = "HeadUp";
            else if  (underDir == Vector3.up)
                spriteName = "HeadDown";
            else if  (underDir == Vector3.right)
                spriteName = "HeadLeft";
            else if  (underDir == Vector3.left)
                spriteName = "HeadRight";
            
            if (body[bodypartInt].blue)
                return blueSprites.First(bodypart => bodypart.name == spriteName).sprite;
            else
                return redSprites.First(bodypart => bodypart.name == spriteName).sprite;
        }

        try
        {
            underDir = body[bodypartInt - 1].transform.position - body[bodypartInt].transform.position;
        }
        catch(ArgumentOutOfRangeException)
        {
            if (overDir == Vector3.down)
                spriteName = "HeadUp";
            else if  (overDir == Vector3.up)
                spriteName = "HeadDown";
            else if  (overDir == Vector3.right)
                spriteName = "HeadLeft";
            else if  (overDir == Vector3.left)
                spriteName = "HeadRight";
            
            if (body[bodypartInt].blue)
                return blueSprites.First(bodypart => bodypart.name == spriteName).sprite;
            else
                return redSprites.First(bodypart => bodypart.name == spriteName).sprite;
        }


        if ((overDir == Vector3.right || overDir == Vector3.left) && (underDir == Vector3.left || underDir == Vector3.right))
            spriteName = "Horizontal";
        else if ((overDir == Vector3.up && underDir == Vector3.down) || (overDir == Vector3.down && underDir == Vector3.up))
            spriteName = "Vertical";
        else if ((overDir == Vector3.down || overDir == Vector3.right) && (underDir == Vector3.right || underDir == Vector3.down))
            spriteName = "DownRight";
        else if ((overDir == Vector3.down || overDir == Vector3.left) && (underDir == Vector3.left || underDir == Vector3.down))
            spriteName = "DownLeft";
        else if ((overDir == Vector3.up || overDir == Vector3.right) && (underDir == Vector3.right || underDir == Vector3.up))
            spriteName = "UpRight";
        else if ((overDir == Vector3.up || overDir == Vector3.left) && (underDir == Vector3.left || underDir == Vector3.up))
            spriteName = "UpLeft";

        if (body[bodypartInt].blue)
            return blueSprites.FirstOrDefault(bodypart => bodypart.name == spriteName).sprite;
        else
            return redSprites.FirstOrDefault(bodypart => bodypart.name == spriteName).sprite;
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

        if ((Vector3)dir == (body[1].transform.position - body[0].transform.position))
            dir = Vector2.zero;
    }

    [System.Serializable]
    public class BodySprite
    {
        public string name;
        public Sprite sprite;
    }
}
