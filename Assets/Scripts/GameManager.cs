using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject dialoguemanager;
    public GameObject npc;
    public GameObject player;
    public GameObject gameover;
    public bool stay = false;
    public float count = 0;
    public float killcount = 0;

    private void Update()
    {
        if(count >= 3)
        {
            if(Input.GetKeyDown(KeyCode.Z) && stay)
            {
                KillNPC();
            }
            
        }
        if(killcount >= 3)
        {
            KillPlayer();
        }
    }

    public void KillNPC()
    {
        
        npc = dialoguemanager.GetComponent<DialogueManagerNew>().npc;
        if (npc.GetComponent<TestScript>().alive == true)
        {
            killcount += 1;
        }
        npc.GetComponent<TestScript>().alive = false;
        Debug.Log(npc.name + " is ded" + " number of ded = " + killcount);
    }

    public void KillPlayer()
    {
        player.GetComponent<PlayerMovement>().speed = 0;
        player.GetComponent<PlayerMovement>().anim.enabled = false;
        gameover.SetActive(true);
    }
}
