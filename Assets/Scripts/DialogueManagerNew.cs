using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagerNew : MonoBehaviour
{
    public static DialogueManagerNew instance;
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Fix this" + gameObject.name);
        }
        else
        {
            instance = this;
        }
    }

    public GameObject dialogueBox;

    public Text dialogueName;
    public Text dialogueText;
    public Image dialoguePortrait;

    public Queue<DialogueBase.Info> dialogueInfo = new Queue<DialogueBase.Info>();

    public void EnqueueDialogue(DialogueBase db)
    {
        dialogueInfo.Clear();

        foreach(DialogueBase.Info info in db.dialogueInfo)
        {
            dialogueInfo.Enqueue(info);
        }

        DequeueDialogue();
    }

    public void DequeueDialogue()
    {
        if(dialogueInfo.Count == 0)
        {
            EndofDialogue();
            return;
        }

        DialogueBase.Info info = dialogueInfo.Dequeue();

        dialogueName.text = info.myName;
        dialogueText.text = info.myText;
        dialoguePortrait.sprite = info.portrait;
    }

    public void EndofDialogue()
    {
        dialogueBox.SetActive(false);
    }
}
