using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nametxt;
    public Text dialogtxt;
    public GameObject dialogbox;
    public string lastDialogue;
    public bool interact;

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        nametxt.text = dialogue.name;

        sentences.Clear();
        foreach(string sentence in dialogue.sentences)
        {
            if(NPC.talked == true){
                sentences.Enqueue(lastDialogue);
                break;
            }
            else{
                lastDialogue = sentence;
                sentences.Enqueue(sentence);
                //print(lastDialogue);
            }
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {

        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        if(sentences.Count == 1){
            //n.firstInteract == false;
            NPC.talked = true;
        }

        string s = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(s));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogtxt.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogtxt.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        dialogbox.SetActive(false);
    }
}
