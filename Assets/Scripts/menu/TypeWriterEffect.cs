using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class TypeWriterEffect : MonoBehaviour {

    HashSet<char> punctuationSigns = new HashSet<char> {'.', ',', '?', ':', ';' , '!'};

    private TMP_Text textBox;

    private int currentVisibleCharacterIndex;
    private Coroutine typewriterCoroutine;

    private WaitForSeconds simpleDelay;
    private WaitForSeconds interpunctuationDelay;

    [Header("Settings")]
    [SerializeField] private float charactersPerSecond = 20f;
    [SerializeField] private float interpunctuationSecondsDelay= 0.5f;

    private void Awake() {
        textBox = GetComponent<TMP_Text>();

        simpleDelay = new WaitForSeconds(1 / charactersPerSecond);
        interpunctuationDelay = new WaitForSeconds(interpunctuationSecondsDelay);
    }

    private void Start() {
        textBox.maxVisibleCharacters = 0;
        currentVisibleCharacterIndex = 0;

        typewriterCoroutine = StartCoroutine(Typewriter());
    }


    private IEnumerator Typewriter() {
        yield return simpleDelay;
        TMP_TextInfo textInfo = textBox.textInfo;

        while(currentVisibleCharacterIndex < textInfo.characterCount){
            char character = textInfo.characterInfo[currentVisibleCharacterIndex].character;
            textBox.maxVisibleCharacters++;

            if (punctuationSigns.Contains(character))
                yield return interpunctuationDelay;
            else
                yield return simpleDelay;
            
            currentVisibleCharacterIndex++;
        }

    }
}