using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 1.
 a. Zidane De Cantuaria
 b. 002325417
 c. decantuaria@chapman.edu  
 d. CPSC 245-01
 e. Final Project - Dialogue System
 f. This is my own work, and I did not cheat on this assignment.
  
2. DialogueManager is a singleton instance that controls all dialogue related UI in the game, accessing info
    from NPCs to print lines and images to the screen. If the NPC conversation that is activated is identified 
    as a branching conversation, dialogue options will also be given to the play at certain points.

*/

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueUI;
    public GameObject optionsUI;
    public Text optionOne;
    public Text optionTwo;
    public Text speakerNameText;
    public Text dialogueBoxText;
    public Image dialogueSprite;
    public TypewriterEffect typewriterEffect;

    private static DialogueManager dialogueManagerInstance; //for creating instance
    private int currBox;
    private int currResponse = -1;
    private bool hasAnswered = false;


    // Start is called before the first frame update
    void Start()
    {
        DisableDialogueUI();
        DisableOptionsUI();
    }

    public static DialogueManager Instance //for creating instance
    {
        get { return dialogueManagerInstance; }
    }

    private void Awake() //creates instance
    {
        if (dialogueManagerInstance != null && dialogueManagerInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        dialogueManagerInstance = this;
        DontDestroyOnLoad(this.gameObject); //prevents object from being destroyed on scene reload
    }

    //pass conversation into this script when the player collides with the npc and interacts with them
    public IEnumerator AdvanceDialogue(Conversation convo)
    {
        currBox = 0;
        EnableDialogueUI();

        //check if the conversation is the derived class and cast it as a branching conversation
        if (convo.GetType() == typeof(BranchingConversation))
        {
            BranchingConversation branchConvo = convo as BranchingConversation;
            while(currBox != -1)
            {
                dialogueSprite.sprite = branchConvo.dialogueSprites[currBox];
                speakerNameText.text = branchConvo.speakerNames[currBox];

                //behavoir for when the conversation is at a branch point
                if (branchConvo.isBranchPoint[currBox] == true)
                {
                    yield return typewriterEffect.Run(branchConvo.dialogueBoxes[currBox], dialogueBoxText);
                    optionTwo.text = branchConvo.playerOptionTwo[currBox];
                    optionOne.text = branchConvo.playerOptionOne[currBox];
                    yield return new WaitForSeconds(.5f);
                    EnableOptionsUI();
                    StartCoroutine(WaitForKeyDown(new KeyCode[] { KeyCode.Alpha1, KeyCode.Alpha2 }));
                    yield return new WaitUntil(() => hasAnswered);
                    //update curr box based on dialogue pointer array
                    if (currResponse == 0)
                    {
                        currBox = branchConvo.dialoguePointerOne[currBox];
                    }

                    else if(currResponse == 1)
                    {
                        currBox = branchConvo.dialoguePointerTwo[currBox];
                    }
                    DisableOptionsUI();
                    currResponse = -1;
                }

                //behavoir when not at a branch point
                else
                {
                    yield return typewriterEffect.Run(branchConvo.dialogueBoxes[currBox], dialogueBoxText);
                    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
                    currBox = branchConvo.dialoguePointerOne[currBox];
                }
            }
        }

        //if the conversation is linear, simply iterate through the dialogue
        else
        {
            foreach (string dialogue in convo.dialogueBoxes)
            {
                speakerNameText.text = convo.speakerNames[currBox];
                dialogueSprite.sprite = convo.dialogueSprites[currBox];
                yield return typewriterEffect.Run(dialogue, dialogueBoxText);
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
                currBox += 1;
            }
        }

        DisableDialogueUI();
    }

    IEnumerator WaitForKeyDown(KeyCode[] codes)
    {
        hasAnswered = false;
        while (!hasAnswered)
        {
            foreach (KeyCode k in codes)
            {
                if (Input.GetKey(k))
                {
                    hasAnswered = true;
                    SetChoiceTo(k);
                    break;
                }
            }

            yield return null;
        }
    }

    private void SetChoiceTo(KeyCode keyCode)
    {
        switch (keyCode)
        {
            case (KeyCode.Alpha1):
                currResponse = 0;
                break;
            case (KeyCode.Alpha2):
                currResponse = 1;
                break;
        }
    }

    public void DisableDialogueUI()
    {
        dialogueUI.SetActive(false);
    }

    public void EnableDialogueUI()
    {
        dialogueUI.SetActive(true);
    }

    public void DisableOptionsUI()
    {
        optionsUI.SetActive(false);
    }

    public void EnableOptionsUI()
    {
        optionsUI.SetActive(true);
    }
}
