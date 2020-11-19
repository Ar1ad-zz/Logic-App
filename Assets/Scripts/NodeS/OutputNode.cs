using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputNode : MonoBehaviour
{

    SignalHolder inputSignal;
    // Start is called before the first frame update
    void Start()
    {
        inputSignal = transform.GetComponent<SignalHolder>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inputSignal.signal){
            transform.Find("Circle").GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            transform.Find("Circle").GetComponent<SpriteRenderer>().color = Color.black;
        }
    }
}
