using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputScript : MonoBehaviour
{

    Collider2D clickArea;
    public Collider2D wireArea;
    public bool outputsignal = false;
    OutputSignal outputSignalScript;
    bool isHolding = false;
    SpriteRenderer circleSprite;
    public GameObject output;

    // Wire Variables
    bool wireSpawned = false;
    public Object wireObject;
    GameObject wireGameObject;

    // Other Node Stuff
    
    

    // Start is called before the first frame update
    void Start()
    {
        clickArea = GetComponent<CircleCollider2D>();
        wireArea = transform.Find("InputWireConnector").GetComponent<CircleCollider2D>();
        circleSprite = GetComponentInChildren<SpriteRenderer>();
        outputSignalScript = GetComponentInChildren<OutputSignal>();
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
        
        //Debug.Log("output: " + outputsignal);
        outputSignalScript.signal = outputsignal;
    }
}
