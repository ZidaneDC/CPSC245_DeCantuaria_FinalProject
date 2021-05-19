using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 1.
 a. Zidane De Cantuaria
 b. 002325417
 c. decantuaria@chapman.edu  
 d. CPSC 245-01
 e. Final Project - Dialogue System
 f. This is my own work, and I did not cheat on this assignment.
  
2. NPC is a class that recognizes player input when they are within an NPC's trigger range.
    Once that input is given, NPC will take the dialogue conversations attached to it and
    send it to the DialogueManager to be displayed.

*/
public class NPC : MonoBehaviour
{
    public Conversation Conversation;

    private DialogueManager dialogueManager;
    private bool isInteractable;
    private bool isTalking = false;

    private void Start()
    {
        dialogueManager = DialogueManager.Instance;
        isInteractable = false;
    }

    private void Update()
    {
        if (isInteractable)
        {
            if (Input.GetKeyDown(KeyCode.Space) && isTalking == false)
            {
                isTalking = true;
                StartCoroutine(dialogueManager.AdvanceDialogue(Conversation));
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isInteractable = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isInteractable = false;
            isTalking = false;
        }
    }
}
