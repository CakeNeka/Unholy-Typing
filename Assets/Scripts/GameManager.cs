using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    private static readonly Theme fallbackTheme = Themes.serikaDark;
    public static Theme selectedTheme = fallbackTheme;

    public static GameManager Instance { get; private set; }

    public ScoreCalculator ScoreCalculator { get; private set; } = new ScoreCalculator();
    public UIManager UIManager { get; private set; }
    public GameConfig config;
    public bool IsGameActive { get; private set; } = true;
    public List<WordController> WordControllers { get; private set; } = new List<WordController>();
    public Theme Theme { get; private set; } = selectedTheme;

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
        return GetCurrentInterval(cpm).fallSpeedMultiplier;
    }

    public float getCPMSpawnDelayMultiplier(float cpm) {
        return GetCurrentInterval(cpm).spawnDelayMultiplier;
    }

    public float getCPMScoreMultiplier(float cpm) {
        return GetCurrentInterval(cpm).scoreMultiplier;
    }

    private Interval GetCurrentInterval(float cpm) {
        foreach (Interval interval in config.CPMIntervals) {
            if (cpm >= interval.minCPMValue && cpm < interval.maxCPMValue) {
                return interval;
            }
        }
        return config.CPMIntervals.Last();
    }

    public void GameOver() {
        IsGameActive = false;
        Time.timeScale = 0;
        UIManager.ShowGameOverMenu();
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
