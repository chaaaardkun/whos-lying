using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagerNew : MonoBehaviour
{
    public static DialogueManagerNew instance;
    public GameObject g;
    //public DialogueBase.Info[] lastDialogue;

    
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
    public float delay = 0.001f;
    private int prevDialogueCount;
    public GameObject npc;
    public bool istalked;
    public bool isalive;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "NPC")
        {
            npc = collision.gameObject;
        }
    }


    public Queue<DialogueBase.Info> dialogueInfo = new Queue<DialogueBase.Info>();
    
    public void EnqueueDialogue(DialogueBase db)
    {
        dialogueBox.SetActive(true);
        dialogueInfo.Clear();

        foreach(DialogueBase.Info info in db.dialogueInfo)
        {
            if(npc.GetComponent<TestScript>().talked == true){
                dialogueInfo.Enqueue(info); 
                if(dialogueInfo.Count == prevDialogueCount){
                    //print(dialogueInfo.Count);
                    //deletes other dialogue except the last line.
                    while(dialogueInfo.Count != 0){
                        dialogueInfo.Dequeue();
                    }
                }
            }
            else{
                prevDialogueCount = dialogueInfo.Count;
                dialogueInfo.Enqueue(info);
            }
            
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
        if(dialogueInfo.Count == 1){
            if(npc.GetComponent<TestScript>().talked == false)
            {
                g.GetComponent<GameManager>().count += 1;
            }
            istalked = true;
            npc.GetComponent<TestScript>().talked = istalked;
            //n.firstInteract == false;
            //TestScript.talked = true;
            
            float i = g.GetComponent<GameManager>().count;
            Debug.Log("pira na nakaulay kang player? = " + i);
        }


        DialogueBase.Info info = dialogueInfo.Dequeue();

        dialogueName.text = info.myName;
        dialogueText.text = info.myText;

        StopAllCoroutines();
        StartCoroutine(TypeText(info));
    }

    IEnumerator TypeText(DialogueBase.Info info)
    {
        dialogueText.text = "";

        foreach(char c in info.myText.ToCharArray())
        {
            yield return new WaitForSeconds(delay);
            dialogueText.text += c;
            yield return null;
        }
    }

    public void EndofDialogue()
    {
        dialogueBox.SetActive(false);
    }

    
}
