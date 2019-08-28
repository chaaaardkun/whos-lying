using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCcontrol : MonoBehaviour
{
    public NPC n;
    public GameObject dialogbox;
    private bool firstSpace = true;
    private bool triggerStay = false;
    //public static bool talked;

    private void Update()
    {
        if (Input.GetKeyDown("space") && triggerStay)
        {
            if (firstSpace) {
                firstSpace = false;

                dialogbox.SetActive(true);
                n.TriggerDialogue();
            }
            else {
                //call button next
            }
        }
        if (!dialogbox.activeSelf) {
            firstSpace = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {   
        triggerStay = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        triggerStay = false;
    }
}
