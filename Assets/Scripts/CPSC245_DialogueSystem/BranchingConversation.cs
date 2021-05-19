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
  
2. BranchingConversation is a derived class of Conversation, defining the parts within a bit of NPC
    dialgue where the player has options. Please note that in both this class and Conversation, all 
    arrays must be the same length, as the DialogueManager uses indexes to determine what is displayed when
    and where the conversation will go next.
*/

[CreateAssetMenu(fileName = "BranchingConversation", menuName = "Branching Conversation")]
public class BranchingConversation : Conversation
{
    public bool[] isBranchPoint;
    public string[] playerOptionOne;
    public string[] playerOptionTwo;
    public int[] dialoguePointerOne;
    public int[] dialoguePointerTwo;
}
