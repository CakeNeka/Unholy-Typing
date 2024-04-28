using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }

    public UIManager UIManager { get; private set; }
    public GameConfig config;
    public bool IsGameActive { get; private set; } = true;
    public List<WordController> WordControllers { get; private set; } = new List<WordController>();

    private void Awake() {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this) {
            Destroy(this);
        } else {
            Instance = this;
        }
    }

    private void Start() {
        UIManager = FindObjectOfType<UIManager>();
    }

    public void AddWordController(WordController controller) {
        WordControllers.Add(controller);
    }

    // FIXME Duplicated code
    public float GetCPMFallSpeedMultiplier(float cpm) {
        foreach (Interval interval in config.CPMIntervals) {
            if (cpm >= interval.minCPMValue && cpm < interval.maxCPMValue) {
                return interval.fallSpeedMultiplier;
            }
        }
        Debug.LogError($"FATAL ERROR: Typing power {cpm} is superhuman, please proceed to die");
        return 1;
    }

    public float getCPMSpawnDelayMultiplier(float cpm) {
        foreach (Interval interval in config.CPMIntervals) {
            if (cpm >= interval.minCPMValue && cpm < interval.maxCPMValue) {
                return interval.spawnDelayMultiplier;
            }
        }
        Debug.LogError($"FATAL ERROR: Typing power {cpm} is superhuman");
        return 1;
    }

}
