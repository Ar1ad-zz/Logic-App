using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_nodeInput : MonoBehaviour
{

    public GameObject signalInput;
    public bool signal = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(name + " Signal: " + signal);
    }
}
