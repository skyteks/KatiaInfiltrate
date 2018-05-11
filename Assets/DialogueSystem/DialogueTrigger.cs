using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour, ITrigger
{
    public Conversation dialogue;

    public UnityEvent afterDialogFollowEvent;
    public bool finished { set; get; }

    public void Trigger()
    {
        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
        if (dialogueManager.dialogueRunning)
        {
            dialogueManager.DisplayNextSentence(this);
        }
        else
        {
            dialogueManager.StartDialogue(dialogue, this);
        }
        //Debug.Log("Triggered dialog");
    }
}
