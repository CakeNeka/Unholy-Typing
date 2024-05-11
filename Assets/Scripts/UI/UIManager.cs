using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour {
    private Theme theme;

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


    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private TMP_Text gameOverScoreLabel;

    private void Start() {
        theme = GameManager.Instance.Theme;
        Camera.main.backgroundColor = theme.background;
        averageCPMLast10Label.color = theme.foregroundUI;
        averageCPMLast10.color = theme.foregroundUI;
        averageCPMLabel.color = theme.foregroundUI;
        averageCPM.color = theme.foregroundUI;
        score.color = theme.foregroundUI;
        scoreLabel.color = theme.foregroundUI;

        gameOverPanel.SetActive(false);
    }

    public void SetAverageCPMText(float speed) {
        averageCPM.text = speed.ToString("0");
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
        Debug.Log("TODO: go to main menu");
        // SceneManager.LoadScene(0);
    }

    public void Restart() {
        GameManager.Instance.RestartGame();
    }
}