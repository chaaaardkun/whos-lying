using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonologueTrigger : MonoBehaviour
{
    public GameObject g;
    public GameObject prevnpc;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if(g.GetComponent<TestScript>().talked == false)
        {
            
            if (prevnpc.tag == "Player")
            {
                g.GetComponent<TestScript>().TriggerDialogue();
            }
            else if(prevnpc.tag == "NPC" && prevnpc.GetComponent<TestScript>().talked == true)
            {
                g.GetComponent<TestScript>().TriggerDialogue();
            }
            
        }
    }
}
