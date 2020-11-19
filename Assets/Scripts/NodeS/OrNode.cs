using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrNode : MonoBehaviour
{
    SignalHolder nodeInput0;
    SignalHolder nodeInput1;
    bool outputSignal = false;

    OutputSignal outputSignalScript;

    // Start is called before the first frame update
    void Start()
    {
        nodeInput0 = transform.Find("NodeInput").GetComponent<SignalHolder>();
        nodeInput1 = transform.Find("NodeInput (1)").GetComponent<SignalHolder>();

        outputSignalScript = GetComponentInChildren<OutputSignal>();
    }

    // Update is called once per frame
    void Update()
    {
        outputSignal = nodeInput0.signal || nodeInput1.signal;

        //Debug.Log(name + " signal = " + outputSignal);

        outputSignalScript.signal = outputSignal;
        
    }
}
