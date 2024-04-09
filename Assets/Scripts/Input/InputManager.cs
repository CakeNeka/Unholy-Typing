using System;
using UnityEngine;

public class InputManager : MonoBehaviour {

    private WordManager wordManager;
    private void Start() {
        wordManager = GetComponent<WordManager>();
    }
    void Update() {
        foreach (char letter in Input.inputString) {
            wordManager.TypeLetter(letter);
        }
    }

}
