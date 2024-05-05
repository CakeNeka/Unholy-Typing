using UnityEngine;
using TMPro;
using UnityEditor;

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

    private void Start() {
        theme = GameManager.Instance.Theme;
        Camera.main.backgroundColor = theme.background;
        averageCPMLast10Label.color = theme.foregroundUI;
        averageCPMLast10.color = theme.foregroundUI;
        averageCPMLabel.color = theme.foregroundUI;
        averageCPM.color = theme.foregroundUI;
    }

    public void setAverageCPMText(float speed) {
        averageCPM.text = speed.ToString("0");
    }

    public void setAverageCPMLast10Text(float speed) {
        averageCPMLast10.text = speed.ToString("0");
    }
}