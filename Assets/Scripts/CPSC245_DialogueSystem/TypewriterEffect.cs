using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
