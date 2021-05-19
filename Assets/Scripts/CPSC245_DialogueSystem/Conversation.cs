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
  
2. Conversation is a class that derives from scriptable object so it can be reused in the game, and
    defines what a basic, linear conversation will have in it, as well as acting as base for branching conversations.
    Please note that having empty indexes in the arrays when the dialogueManager is trying to access them
    will cause the program to not behave properly in most cases, and throw a NullReferenceException error.

*/

[CreateAssetMenu(fileName = "Conversation", menuName = "Conversation")]
public class Conversation : ScriptableObject
{
    //sprites for each dialogue box
    public Sprite[] dialogueSprites;

    //strings for each box of dialogue
    [TextArea(3, 15)]
    public string[] dialogueBoxes;

    //strings for each boxes speaker name
    public string[] speakerNames;
}
