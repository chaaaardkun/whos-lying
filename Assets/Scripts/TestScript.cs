using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public DialogueBase dialogue;

    public void TriggerDialogue()
    {
        DialogueManagerNew.instance.EnqueueDialogue(dialogue);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TriggerDialogue();
        }
    }
}
