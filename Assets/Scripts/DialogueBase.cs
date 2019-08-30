using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogues")]
public class DialogueBase : ScriptableObject
{
    [System.Serializable]
    public class Info
    {
        public string myName;
        [TextArea(4, 8)]
        public string myText;
    }
    [Header("Dialogue Information")]
    public Info[] dialogueInfo;
}

