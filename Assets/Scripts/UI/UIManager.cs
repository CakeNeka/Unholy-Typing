using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
    private Theme theme;

    [SerializeField]
    private TMP_Text averageCPMLabel;
    [SerializeField]
    private TMP_Text averageCPMLast10Label;

    [SerializeField]
    private TMP_Text averageCPM;
    [SerializeField]
    private TMP_Text averageCPMLast10;

    [SerializeField]
    private GameObject gameOverPanel;

    private void Start() {
        theme = GameManager.Instance.Theme;
        Camera.main.backgroundColor = theme.background;
        averageCPMLast10Label.color = theme.foregroundUI;
        averageCPMLast10.color = theme.foregroundUI;
        averageCPMLabel.color = theme.foregroundUI;
        averageCPM.color = theme.foregroundUI;

        gameOverPanel.SetActive(false);
    }

    public void SetAverageCPMText(float speed) {
        averageCPM.text = speed.ToString("0");
    }

    public void SetAverageCPMLast10Text(float speed) {
        averageCPMLast10.text = speed.ToString("0");
    }
    public void ShowGameOverMenu() {
        gameOverPanel.SetActive(true);
    }

    public void ExitToMenu() {
        Debug.Log("TODO: go to main menu");
        // SceneManager.LoadScene(0);
    }

    public void Restart() {
        GameManager.Instance.RestartGame();
    }
}