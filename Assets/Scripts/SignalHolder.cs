using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalHolder : MonoBehaviour
{

    public GameObject connectedWire;
    public bool signal = false;

    void Start()
    {
        connectedWire = null;
    }
    // Update is called once per frame
    void Update()
    {
        if( connectedWire == null){
            signal = false;
        }
        Debug.Log(name + " Signal: " + signal);
    }
}
