using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{

    public GameObject nodePanel;
    
    public void OpenNodePanel()
    {
        Animator anim = nodePanel.GetComponent<Animator>();
        if(anim != null)
        {
            bool isOpen = anim.GetBool("Open");
            anim.SetBool("Open", !isOpen);
        }
    }
}
