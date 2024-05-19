using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class UIManager : MonoBehaviour {
    private Theme theme;

    [Header("HUD")]
    [SerializeField] private Image hudBg;
    [SerializeField] private TMP_Text averageCPMLabel;
    [SerializeField] private TMP_Text averageCPMLast10Label;
    [SerializeField] private TMP_Text averageCPM;
    [SerializeField] private TMP_Text averageCPMLast10;
    [SerializeField] private TMP_Text scoreLabel;
    [SerializeField] private TMP_Text score;
    [SerializeField] private TMP_Text accuracyLabel;
    [SerializeField] private TMP_Text accuracy;
    [SerializeField] private TMP_Text wordsTypedLabel;
    [SerializeField] private TMP_Text wordsTyped;
    [SerializeField] private TMP_Text versionLabel;


    [Header("Game Over Screen")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Image gameOverBackground;
    [SerializeField] private TMP_Text gameOverTitle;
    [SerializeField] private MenuButtonHover restartButton;
    [SerializeField] private MenuButtonHover gotoMenuButton;
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private TMP_Text gameOverScore;
    [SerializeField] private TMP_Text gameOverScoreLabel;
    [SerializeField] private TMP_Text gameOverAccuracy;
    [SerializeField] private TMP_Text gameOverAccuracyLabel;
    [SerializeField] private TMP_Text gameOverWordsTyped;
    [SerializeField] private TMP_Text gameOverWordsTypedLabel;


    // [Header("Pause Screen")]
    private void Start() {
        // Set HUD Colors
        theme = GameManager.Instance.Theme;
        Camera.main.backgroundColor = theme.background;
        averageCPMLast10Label.color = theme.foregroundUI;
        averageCPMLast10.color = theme.foregroundTyped;
        averageCPMLabel.color = theme.foregroundUI;
        averageCPM.color = theme.foregroundTyped;
        scoreLabel.color = theme.foregroundUI;
        score.color = theme.foregroundTyped;
        accuracyLabel.color = theme.foregroundUI;
        accuracy.color = theme.foregroundTyped;
        wordsTypedLabel.color = theme.foregroundUI;
        wordsTyped.color = theme.foregroundTyped;
        versionLabel.color = theme.foregroundUI;
        hudBg.color = theme.backgroundUI;

        // Set Game Over Screen colors
        gameOverPanel.SetActive(false);
        gameOverBackground.color = theme.background;
        gameOverTitle.color = theme.foregroundUI;
        gameOverScoreLabel.color = theme.foregroundUI;
        gameOverScore.color = theme.foregroundTyped;
        gameOverAccuracyLabel.color = theme.foregroundUI;
        gameOverAccuracy.color = theme.foregroundTyped;
        gameOverWordsTypedLabel.color = theme.foregroundUI;
        gameOverWordsTyped.color = theme.foregroundTyped;

        restartButton.baseColor = theme.foreground;
        restartButton.hoverColor = theme.foregroundTyped;
        gotoMenuButton.baseColor = theme.foreground;
        gotoMenuButton.hoverColor = theme.foregroundTyped;

        // Set version text
        versionLabel.text = "UT " + Application.version;
    }

    public void SetAverageCPMText(float speed) {
        averageCPM.text = $"{speed:0}";
    }

    public void SetAverageCPMLast10Text(float speed) {
        averageCPMLast10.text = $"({speed:0})";
    }

    public void SetScoreText(int score) {
        TypingSpeedCalculator speedCalculator = GameManager.Instance.SpeedCalculator;

        this.score.text = score.ToString();
        accuracy.text = $"{speedCalculator.Accuracy * 100:0.0}";
        wordsTyped.text = $"{speedCalculator.WordsTyped}";
    }

    public void ShowGameOverMenu() {
        TypingSpeedCalculator speedCalculator = GameManager.Instance.SpeedCalculator;

        gameOverPanel.SetActive(true);
        gameOverScore.text = score.text;
        gameOverAccuracy.text = $"{speedCalculator.Accuracy * 100:0.0}%";
        gameOverWordsTyped.text = $"{speedCalculator.WordsTyped}";
        nameInputField.Select();
        nameInputField.characterLimit = 3;
        nameInputField.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    public void ValueChangeCheck() {
        nameInputField.text = nameInputField.text.Trim().ToUpper();
    }

    public void ExitToMenu() {
        SavePlayToJson();
        SceneManager.LoadScene(0);
    }

    public void Restart() {
        SavePlayToJson();
        GameManager.Instance.RestartGame();
    }

    private void SavePlayToJson() {
        TypingSpeedCalculator speedCalculator = GameManager.Instance.SpeedCalculator;
        ScoreCalculator scoreCalculator = GameManager.Instance.ScoreCalculator;

        ScoreEntry scoreEntry = new(
            name: ParseName(nameInputField.text),
            score: scoreCalculator.CurrentScore,
            averageSpeed: speedCalculator.AverageCPM,
            accuracy: speedCalculator.Accuracy,
            wordsTyped: speedCalculator.WordsTyped
        );
        ScoreJsonSerializer.AddScore(scoreEntry);
    }

    private string ParseName(string name) {
        if (name.Count() == 3)
            return name;
        if (name.Count() == 0)
            return "???";
        return name.PadRight(3, '-');
    }
}