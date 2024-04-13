using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }

    public GameConfig config;
    public List<WordController> WordControllers { get; private set; } = new List<WordController>();

    private void Awake() {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this) {
            Destroy(this);
        } else {
            Instance = this;
        }
    }

    public void AddWordController(WordController controller) {
        WordControllers.Add(controller);
    }
}
