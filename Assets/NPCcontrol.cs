using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCcontrol : MonoBehaviour
{
     public NPC n;
    public GameObject dialogbox;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        dialogbox.SetActive(true);
        n.TriggerDialogue();
    }
}
