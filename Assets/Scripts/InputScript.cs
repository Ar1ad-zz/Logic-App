﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputScript : MonoBehaviour
{

    Collider2D clickArea;
    Collider2D wireArea;
    bool output = false;
    SpriteRenderer circleSprite;
    public Object wireObject;

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
                Debug.Log("Clicked");
                if (!output)
                {
                    output = true;
                    circleSprite.color = Color.red;
                }
                else
                {
                    output = false;
                    circleSprite.color = Color.black;
                }
                
            }
            
        }
        if (Input.GetMouseButton(0))
        {
            if (wireArea.OverlapPoint(mousePos))
            {
                Instantiate(wireObject);
            }
        }
    }
}
