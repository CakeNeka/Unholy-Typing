using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }

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
        return 0;
    }

    public float getCPMSpawnDelayMultiplier(float cpm) {
        foreach (Interval interval in config.CPMIntervals) {
            if (cpm >= interval.minCPMValue && cpm < interval.maxCPMValue) {
                return interval.spawnDelayMultiplier;
            }
        }
        Debug.LogError($"FATAL ERROR: Typing power {cpm} is superhuman");
        return 0;
    }

}
