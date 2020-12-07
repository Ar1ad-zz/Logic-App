using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeButtonScript : MonoBehaviour
{

    public GameObject node;
    public void SpawnNode()
    {
        for(int i = 0; i < 1; i++){
            Instantiate(node, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}
