using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject dialoguemanager;
    public GameObject npc;
    public bool stay = false;
    public float count = 0;
    public float killcount = 0;

    private void Update()
    {
        if(count >= 3)
        {
            if(Input.GetKeyDown(KeyCode.Z) && stay)
            {
                KillPlayer();
            }
            
        }
    }

    public void KillPlayer()
    {
        
        npc = dialoguemanager.GetComponent<DialogueManagerNew>().npc;
        if (npc.GetComponent<TestScript>().alive == true)
        {
            killcount += 1;
        }
        npc.GetComponent<TestScript>().alive = false;
        Debug.Log(npc.name + " is ded" + " number of ded = " + killcount);
    }
}
