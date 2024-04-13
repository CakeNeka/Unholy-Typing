using System;
using UnityEngine;

public class InputManager : MonoBehaviour {

    private TypingManager wordManager;
    private void Start() {
        wordManager = GetComponent<TypingManager>();
    }
    void Update() {
        foreach (char letter in Input.inputString) {
            wordManager.TypeLetter(letter);
        }
    }

}
