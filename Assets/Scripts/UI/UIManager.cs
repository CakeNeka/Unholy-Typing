using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour {
    [SerializeField]
    private TMP_Text averageCPMLabel;
    [SerializeField]
    private TMP_Text averageCPMLast10Label;

    [SerializeField]
    private TMP_Text averageCPM;
    [SerializeField]
    private TMP_Text averageCPMLast10;
    public void setAverageCPMText(float speed) {
        averageCPM.text = speed + "";
    }

    public void setAverageCPMLast10Text(float speed) {
        averageCPMLast10.text = speed + "";
    }
}