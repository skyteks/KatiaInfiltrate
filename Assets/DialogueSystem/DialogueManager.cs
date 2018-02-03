using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
	public bool dialogueRunning;
	public GameObject dialogueWindow;
	public Text dialogueText;
	public Image dialoguePortraitLeft;
	public Image dialoguePortraitRight;
	public GameObject dialogueSpaceingLeft;
	public GameObject dialogueSpaceingRight;
	private Queue<Dialogue> dialogues;

	void Start ()
	{
		dialogues = new Queue<Dialogue>();
		EndDialogue();
	}

    public void StartDialogue(Conversation conversation)
    {
        dialogues.Clear();
		foreach (var dialogue in conversation.dialogues)
		{
			dialogues.Enqueue(dialogue);
		}
		dialogueWindow.SetActive(true);
		//Debug.Log("Start Dialogue");
		DisplayNextSentence();
		dialogueRunning = true;
    }

    public void DisplayNextSentence()
    {
        if (dialogues.Count == 0)
		{
			EndDialogue();
			return;
		}

		Dialogue dialogue = dialogues.Dequeue();
		dialogueText.text = dialogue.sentence;
		SetDialoguePortrait(dialogue.portrait, dialogue.side);
		//Debug.Log("Dialogue: " + dialogue);
    }

	private void SetDialoguePortrait(Sprite sprite, Dialogue.Sides side)
	{
		Image used;
		Image unused;
		if (side == Dialogue.Sides.Left)
		{
			used = dialoguePortraitLeft;
			unused = dialoguePortraitRight;
			dialogueSpaceingLeft.SetActive(true);
			dialogueSpaceingRight.SetActive(false);
		}
		else// if (side == Dialogue.Sides.Right)
		{
			used = dialoguePortraitRight;
			unused = dialoguePortraitLeft;
			dialogueSpaceingRight.SetActive(true);
			dialogueSpaceingLeft.SetActive(false);
		}
		used.sprite = sprite;
		used.color = Color.white;
		unused.sprite = null;
		unused.color = Color.clear;
	}

    private void EndDialogue()
    {
		//Debug.Log("End Dialogue");
		dialogueText.text = "";
		dialogueWindow.SetActive(false);
		dialogueRunning = false;
    }
}
