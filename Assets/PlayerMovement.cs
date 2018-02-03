using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rigid;

    private float x;
    private float y;

    private DialogueTrigger dialogueTrigger;
    private DialogueManager dialogueManager;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    void Update()
    {
        if (dialogueManager != null)
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (dialogueManager.dialogueRunning)
                {
                    dialogueManager.DisplayNextSentence();
                }
                else
                {
                    if (dialogueTrigger != null)
                    {
                        dialogueTrigger.TriggerDialogue();
                    }
                }
            }

            if (dialogueManager.dialogueRunning) return;
        }

        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(x) > 0.1f)
        {
            rigid.AddForce(x * Vector3.right * Time.fixedDeltaTime * speed);
        }
        if (Mathf.Abs(y) > 0.1f)
        {
            rigid.AddForce(y * Vector3.up * Time.fixedDeltaTime * speed);
        }
        x = 0;
        y = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DialogueTrigger trigger = other.GetComponent<DialogueTrigger>();
        if (trigger != null) dialogueTrigger = trigger;
        //Debug.Log("Entered trigger");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        DialogueTrigger trigger = other.GetComponent<DialogueTrigger>();
        if (trigger != null && trigger == dialogueTrigger) dialogueTrigger = null;
        //Debug.Log("Left trigger");
    }
}
