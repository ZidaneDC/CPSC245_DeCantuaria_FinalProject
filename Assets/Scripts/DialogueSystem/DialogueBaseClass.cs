using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class DialogueBaseClass : MonoBehaviour
    {
        public bool isFinished { get; protected set; }

        protected IEnumerator WriteText(string input, Text textHolder, float delay, AudioClip sound)
        {
            for (int i = 0; i < input.Length; i++)
            {
                textHolder.text += input[i];
                SoundManager.Instance.PlaySound(sound);
                yield return new WaitForSeconds(delay);
            }
            yield return WaitForKeyDown(KeyCode.Space);
            isFinished = true;
        }

        IEnumerator WaitForKeyDown(KeyCode keyCode)
        {
            while (!Input.GetKeyDown(keyCode))
                yield return null;
        }
    }

}