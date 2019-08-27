using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCcontrol : MonoBehaviour
{
     public NPC n;
    public GameObject dialogbox;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && triggerStay)
        {
            dialogbox.SetActive(true);
            n.TriggerDialogue();
        }
    }

bool triggerStay = false;
    private void OnTriggerStay2D(Collider2D collision)
    {   
        triggerStay = true;
    }
}
