using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour
{
    Collider2D col;
    bool isHolding = false;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        

        

        if (Input.GetMouseButton(0))
        {
            //Debug.Log(isHolding);
            //Debug.Log("Holding");
            if (col.OverlapPoint(mousePos))
            {
                isHolding = true;
            }
            if (isHolding)
            {
                transform.position = mousePos;  
            }

        }
        else
        {
            isHolding = false;
        }
    }
}
