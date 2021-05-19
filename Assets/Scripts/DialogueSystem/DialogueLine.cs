using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class DialogueLine : DialogueBaseClass
    {
        private Text textHolder;

        [Header("Text Options")]
        [SerializeField] private string input;

        [Header("Time Parameters")]
        [SerializeField] private float delay = .1f;

        [Header("Sound")]
        [SerializeField] private AudioClip sound;

        //could use a similar format and both sides of the dialogue boxes under one parent to switch sides between speakers
        [Header("Character Image")]
        [SerializeField] private Sprite characterSprite;
        [SerializeField] private Image imageHolder;

        private void Awake()
        {
            
            imageHolder.sprite = characterSprite;
            imageHolder.preserveAspect = true;
        }
        private void OnEnable()
        {
            ResetLine();
            StartCoroutine(WriteText(input, textHolder, delay, sound));
        }

        private void ResetLine()
        {
            textHolder = GetComponent<Text>();
            textHolder.text = "";
            isFinished = false;

        }
    }
}
