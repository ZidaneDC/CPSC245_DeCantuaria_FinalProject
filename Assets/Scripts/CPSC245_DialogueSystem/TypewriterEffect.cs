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
  
1. TypewriterEffect is a class that prints text letter by letter to create a scrolling effect.

*/

public class TypewriterEffect : MonoBehaviour
{
    [SerializeField] private float writeSpeed = 40f;
    [SerializeField] private AudioClip sound;
    public Coroutine Run(string textToType, Text textbox)
    {
        return StartCoroutine(TypeText(textToType, textbox));
    }

    private IEnumerator TypeText(string textToType, Text textbox)
    {
        textbox.text = string.Empty;

        float t = 0;
        int charIndex = 0;

        while (charIndex < textToType.Length)
        {
            SoundManager.Instance.PlaySound(sound);
            t += Time.deltaTime * writeSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            textbox.text = textToType.Substring(0, charIndex);

            yield return null;
        }

        textbox.text = textToType;
    }
}
