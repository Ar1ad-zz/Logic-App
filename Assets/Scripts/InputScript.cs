using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputScript : MonoBehaviour
{

    Collider2D clickArea;
    Collider2D wireArea;
    bool outputsignal = false;
    SpriteRenderer circleSprite;
    public Object wireObject;
    public GameObject output;

    //other node
    S_nodeInput hitScript;

    // Start is called before the first frame update
    void Start()
    {
        clickArea = GetComponent<CircleCollider2D>();
        wireArea = GetComponentInChildren<CircleCollider2D>();
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

        // select wireconnector and instantiate wire
        //if (wireArea.OverlapPoint(mousePos))
        //{
        //    if (Input.GetMouseButton(0))
        //    {
        //        Instantiate(wireObject);
        //    }

        //}

        RaycastHit2D hit = new RaycastHit2D();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics2D.Raycast(ray.origin, ray.direction))
        {
            hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (!Input.GetMouseButtonDown(0))
            {
                hitScript = hit.transform.GetComponent<S_nodeInput>();
                
                Collider2D col = hit.transform.GetComponent<CircleCollider2D>();
                Debug.Log(col + ",  " + col.name);
            }
            
        }

        hitScript.signal = outputsignal;
        Debug.Log("output: " + outputsignal);


    }
}
