using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalHolder : MonoBehaviour
{

    public GameObject signalInput;
    public bool signal = false;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(name + " Signal: " + signal);
    }
}
