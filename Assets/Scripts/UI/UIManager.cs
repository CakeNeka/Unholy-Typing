using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    private Theme theme;

    [Header("HUD")]
    [SerializeField]
    private TMP_Text averageCPMLabel;
    [SerializeField]
    private TMP_Text averageCPMLast10Label;
    [SerializeField]
    private TMP_Text scoreLabel;

    [SerializeField]
    private TMP_Text averageCPM;
    [SerializeField]
    private TMP_Text averageCPMLast10;
    [SerializeField]
    private TMP_Text score;


    [Header("Game Over Screen")]
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private Image gameOverBackground;
    [SerializeField]
    private TMP_Text gameOverScoreLabel;
    [SerializeField]
    private TMP_Text gameOverTitle;
    [SerializeField]
    private MenuButtonHover restartButton;
    [SerializeField]
    private MenuButtonHover gotoMenuButton;
    
     
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

        // Set Game Over Screen colors
        gameOverPanel.SetActive(false);
        gameOverBackground.color = theme.background;
        gameOverTitle.color = theme.foregroundUI;
        gameOverScoreLabel.color = theme.foregroundTyped;
        restartButton.baseColor = theme.foreground;
        gotoMenuButton.baseColor = theme.foreground;
        restartButton.hoverColor = theme.foregroundTyped;
        gotoMenuButton.hoverColor = theme.foregroundTyped;
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
        gameOverScoreLabel.text = score.text;
    }

    public void ExitToMenu() {
        SceneManager.LoadScene(0);
    }

    public void Restart() {
        GameManager.Instance.RestartGame();
    }
}