using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connector : MonoBehaviour
{
    Collider2D connectorArea;
    GameObject wireGameObject;
    public Object wireObject;
    bool wireSpawned = false;
    bool isHolding = false;
    RaycastHit2D hit;
    SignalHolder hitScript;
    Collider2D col;

    // Start is called before the first frame update
    void Start()
    {
        connectorArea = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // select wireconnector and instantiate wire
        if (Input.GetMouseButton(0))
        {
            if (connectorArea.OverlapPoint(mousePos))
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
                
                if (Physics2D.Raycast(ray.origin, ray.direction))
                {
                    hit = Physics2D.Raycast(ray.origin, ray.direction);
                    if (!Input.GetMouseButtonDown(0))
                    {
                        hitScript = hit.transform.GetComponent<SignalHolder>();

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

        // Update Wire Positions
        wireGameObject.GetComponent<LineRenderer>().SetPosition(0, transform.position);
        wireGameObject.GetComponent<LineRenderer>().SetPosition(1, hit.transform.position);


        // direct the signal
        hitScript.signal = transform.parent.GetComponent<OutputSignal>().signal;

        // change colors
        if (transform.parent.GetComponent<OutputSignal>().signal)
        {
            wireGameObject.GetComponent<LineRenderer>().startColor = Color.red;
            wireGameObject.GetComponent<LineRenderer>().endColor = Color.red;
        }
        else
        {
            wireGameObject.GetComponent<LineRenderer>().startColor = new Color32(40, 40, 40, 255);
            wireGameObject.GetComponent<LineRenderer>().endColor = new Color32(40, 40, 40, 255);
        }
    }
}
