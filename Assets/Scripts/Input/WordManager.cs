using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

/// <summary>
/// Translates user input into actions and effects
/// Only one instance of this script should exist on scene
/// </summary>
public class WordManager : MonoBehaviour {
    [SerializeField]
    private List<WordController> wordControllers = new List<WordController>();
    [SerializeField]
    private WordController activeWord = null;
    private RandomWordGenerator wordGenerator;
    [SerializeField]
    GameObject wordPrefab;

    private void Start() {
        wordGenerator = GetComponent<RandomWordGenerator>();
        StartCoroutine(SpawnRepeating());
    }

    // TODO move word spawning to another script
    IEnumerator SpawnRepeating() {
        int i = 0;
        while (true) {
            yield return new WaitForSeconds(2f);
            if (i++ % 2 == 0)
                SpawnWordGameObject(DifficultyLevel.Wimp);
            else
                SpawnWordGameObject(DifficultyLevel.Leet);
        }
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
        // If there's no active word and no word starts by the typed letter then return. 
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
                wordControllers.Remove(activeWord);
                activeWord = null;
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
