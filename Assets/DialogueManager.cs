using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nametxt;
    public Text dialogtxt;
    public GameObject dialogbox;

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
            sentences.Enqueue(sentence);
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
