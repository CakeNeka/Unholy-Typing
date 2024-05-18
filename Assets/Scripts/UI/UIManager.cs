using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    private Theme theme;

    [Header("HUD")]
    [SerializeField] private TMP_Text averageCPMLabel;
    [SerializeField] private TMP_Text averageCPMLast10Label;
    [SerializeField] private TMP_Text scoreLabel;
    [SerializeField] private TMP_Text averageCPM;
    [SerializeField] private TMP_Text averageCPMLast10;
    [SerializeField] private TMP_Text score;
    [SerializeField] private Image hudBg;
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
        averageCPMLast10.color = theme.foregroundUI;
        averageCPMLabel.color = theme.foregroundUI;
        averageCPM.color = theme.foregroundUI;
        score.color = theme.foregroundUI;
        scoreLabel.color = theme.foregroundUI;
        versionLabel.color = theme.foregroundUI;

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
        this.score.text = score.ToString();
    }
    public void ShowGameOverMenu() {
        gameOverPanel.SetActive(true);
        gameOverScore.text = score.text;
        nameInputField.Select();
    }

    public void ExitToMenu() {
        SceneManager.LoadScene(0);
    }

    public void Restart() {
        GameManager.Instance.RestartGame();
    }
}