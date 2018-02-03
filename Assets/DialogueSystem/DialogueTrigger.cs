using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Conversation dialogue;

	public void TriggerDialogue()
	{
		var manager = FindObjectOfType<DialogueManager>();
		manager.StartDialogue(dialogue);
		//Debug.Log("Triggered dialog");
	}
}
