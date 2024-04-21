using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour {
    [SerializeField]
    private TMP_Text averageCPM;
    [SerializeField]
    private TMP_Text averageCPMLast10Text;
    public void setAverageCPMText(string text) {
        averageCPM.text = text;
    }

    public void setAverageCPMLast10Text(string text) {
        averageCPMLast10Text.text = text;
    }
}