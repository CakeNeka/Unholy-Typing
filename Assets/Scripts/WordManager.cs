using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

/// <summary>
/// Translates user input into actions and effects
/// </summary>
public class WordManager : MonoBehaviour {
    [SerializeField]
    private List<WordController> wordControllers = new List<WordController>();
    [SerializeField]
    private WordController activeWord = null;

    [SerializeField]
    RandomWordGenerator wordGenerator;
    [SerializeField]
    GameObject wordPrefab;

    private void Start() {
        SpawnWordGameObject(DifficultyLevel.Wimp);
    }

    public void SpawnWordGameObject(DifficultyLevel difficulty) {
        // generate random word
        Word word = wordGenerator.generateWord(difficulty);
        // Instantiate word GO
        WordController controller = Instantiate(wordPrefab).GetComponent<WordController>();
        controller.SetWord(word);
        wordControllers.Add(controller);
    }

    public void TypeLetter(char letter) {
        if (!activeWord && !TryFindWord(letter)) {
            return;
        }

        Assert.IsNotNull(activeWord);
        if (activeWord.IsNextLetter(letter)) {
            activeWord.TypeLetter();
            // TODO reward
            if (activeWord.WordTyped()) {
                // remove word if already typed
                activeWord.DestroySelf();
                activeWord = null;
                wordControllers.Remove(activeWord);
            }
        } else {
            // TODO penalize
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
        return activeWord != null;
    }
}
