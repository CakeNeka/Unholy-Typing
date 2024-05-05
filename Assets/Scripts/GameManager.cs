using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    private static Color getColor(string hexColor) {
        if (ColorUtility.TryParseHtmlString(hexColor, out Color color)) {
            return color;
        }
        return Color.black;
    }
    private static Theme fallbackTheme = new(
        background: getColor("#323437"),
        foreground: getColor("#d1d0c5"),
        foregroundTyped: getColor("#e2b714"),
        foregroundUI: getColor("#ca4754")
    );

    public static GameManager Instance { get; private set; }

    public UIManager UIManager { get; private set; }
    public GameConfig config;
    public bool IsGameActive { get; private set; } = true;
    public List<WordController> WordControllers { get; private set; } = new List<WordController>();
    public Theme Theme { get; private set; } = fallbackTheme;

    private void Awake() {
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

    public float GetCPMFallSpeedMultiplier(float cpm) {
        foreach (Interval interval in config.CPMIntervals) {
            if (cpm >= interval.minCPMValue && cpm < interval.maxCPMValue) {
                return interval.fallSpeedMultiplier;
            }
        }
        Debug.LogError($"ERROR: Typing power {cpm} is too high");
        return 1;
    }

    public float getCPMSpawnDelayMultiplier(float cpm) {
        foreach (Interval interval in config.CPMIntervals) {
            if (cpm >= interval.minCPMValue && cpm < interval.maxCPMValue) {
                return interval.spawnDelayMultiplier;
            }
        }
        Debug.LogError($"ERROR: Typing power {cpm} is too high");
        return 1;
    }

    public void GameOver() {
        // TODO Gameover screen w/ options go to menu and play again
        IsGameActive = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
