using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public DialogueBase dialogue;
    public bool talked;
    public bool alive = true;
    private bool firstSpace = true;
    private bool triggerStay = false;
    public GameObject dialogueBox;
    

    public void TriggerDialogue()
    {
        DialogueManagerNew.instance.EnqueueDialogue(dialogue);
    }
        
    public void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space) && triggerStay){
            if (firstSpace) {
                firstSpace = false;
                dialogueBox.SetActive(true);
                TriggerDialogue();
            }
            else{
                //Call next button
                DialogueManagerNew.instance.DequeueDialogue();
            }
        }
        if (!dialogueBox.activeSelf) {
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
