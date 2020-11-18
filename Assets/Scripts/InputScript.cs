using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputScript : MonoBehaviour
{

    Collider2D clickArea;
    public Collider2D wireArea;
    bool outputsignal = false;
    bool isHolding = false;
    SpriteRenderer circleSprite;
    public GameObject output;

    // Wire Variables
    bool wireSpawned = false;
    public Object wireObject;
    GameObject wireGameObject;

    // Other Node Stuff
    S_nodeInput hitScript;
    RaycastHit2D hit;

    // Start is called before the first frame update
    void Start()
    {
        clickArea = GetComponent<CircleCollider2D>();
        wireArea = transform.Find("InputWireConnector").GetComponent<CircleCollider2D>();
        circleSprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (clickArea.OverlapPoint(mousePos))
            {
                
                if (!outputsignal)
                {
                    outputsignal = true;
                    circleSprite.color = Color.red;
                }
                else
                {
                    outputsignal = false;
                    circleSprite.color = Color.black;
                }
                
            }
            
        }

        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // select wireconnector and instantiate wire
        if (Input.GetMouseButton(0))
        {
            if (wireArea.OverlapPoint(mousePos))
            {
                isHolding = true;
                //Debug.Log("Holding");
            }
            if (isHolding)
            {
                
                if (!wireSpawned)
                {
                    wireSpawned = true;
                    wireGameObject = (GameObject)Instantiate(wireObject);
                    
                    
                }
                
                wireGameObject.GetComponent<LineRenderer>().SetPosition(0, wireArea.transform.position);
                if (Physics2D.Raycast(ray.origin, ray.direction))
                {
                    hit = Physics2D.Raycast(ray.origin, ray.direction);
                    if (!Input.GetMouseButtonDown(0))
                    {
                        hitScript = hit.transform.GetComponent<S_nodeInput>();

                        Collider2D col = hit.transform.GetComponent<CircleCollider2D>();

                        Debug.Log(col + ",  " + col.name);

                        
                    }
                }


            }
        }
        else
        {
            isHolding = false;
        }

        wireGameObject.GetComponent<LineRenderer>().SetPosition(1, hit.transform.position);
        hitScript.signal = outputsignal;
        Debug.Log("output: " + outputsignal);


    }
}
