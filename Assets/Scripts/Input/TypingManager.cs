using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

/// <summary>
/// Translates user input into actions and effects
/// Only one instance of this script should exist on scene
/// </summary>
public class TypingManager : MonoBehaviour {
    private List<WordController> wordControllers;
    private WordController activeWord = null;
    private ProgressionManager progressionManager;
    [SerializeField] private GameObject explosionEffect;

    private void Start() {
        wordControllers = GameManager.Instance.WordControllers;
        progressionManager = GetComponent<ProgressionManager>();
    }

    public void TypeLetter(char letter) {
        // If there's no active word and no word starts by the typed letter then return. 
        if (!activeWord && !TryFindWord(letter)) {
            return;
        }

        Assert.IsNotNull(activeWord);
        if (activeWord.IsNextLetter(letter)) {
            activeWord.TypeLetter();
            if (activeWord.WordTyped()) {
                // remove word if already typed
                activeWord.ToggleTimer();
                progressionManager.AddToAverageCPM(activeWord);

                activeWord.DestroySelf();
                wordControllers.Remove(activeWord);
                activeWord = null;
            }
        } else {
            activeWord?.AddMiss();
        }
    }

    public void DestroyMissedWord(WordController word) {
        if (activeWord == word) {
            activeWord = null;
        }
        word.DestroySelf();
        wordControllers.Remove(word);
        Instantiate(explosionEffect, word.transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Word") && other.TryGetComponent<WordController>(out WordController word)) {
            DestroyMissedWord(word);
            progressionManager.MissWord();
        }
    }


    private bool TryFindWord(char letter) {
        foreach (var word in wordControllers) {
            bool validLetter = word.IsNextLetter(letter);
            bool activeWordIsNullOrFar = !activeWord || (activeWord && word.transform.position.y < activeWord.transform.position.y);
            if (validLetter && activeWordIsNullOrFar) {
                activeWord = word;
            }
        }
        if (activeWord) {
            activeWord.ToggleTimer();
            return true;
        }
        return false;
    }

    public void StopFocus() {
        if (activeWord != null) {
            activeWord.ToggleTimer();
            activeWord = null;
        }
    }
}
