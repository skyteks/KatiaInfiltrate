using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    public Conversation dialogue;

    public UnityEvent afterDialogFollowEvent;
    public bool finished { set; get; }

    public void TriggerDialogue()
    {
        var dialogueManager = FindObjectOfType<DialogueManager>();
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
