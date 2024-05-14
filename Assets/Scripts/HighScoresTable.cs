using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class HighScoresTable : MonoBehaviour {
    [SerializeField] private Transform entryTemplate;
    [SerializeField] private Transform entryContainer;

    private void Awake() {
        SetDummyScores();
    }

    private void SetDummyScores() {
        SetHighScores(
            new List<ScoreEntry>{
                new("nno", 234),
                new("nka", 234),
                new("mrt", 234),
                new("lsi", 234),
                new("neo", 234),
                new("emo", 234),
            }
        );
    }

    public void SetHighScores(List<ScoreEntry> scores) {
        scores = scores.OrderBy(s => s.score).ToList();
        entryTemplate.gameObject.SetActive(false);
        
        float templateHeight = entryTemplate.GetComponent<RectTransform>().sizeDelta.y;

        for (int i = 0; i < scores.Count(); i++) {
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();

            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            entryTransform.gameObject.SetActive(true);

            int rank = i + 1;
            entryTransform.Find("posText").GetComponent<TMP_Text>().text = rank.ToString();
            entryTransform.Find("scoreText").GetComponent<TMP_Text>().text = scores[i].score.ToString();
            entryTransform.Find("nameText").GetComponent<TMP_Text>().text = scores[i].name.ToString();
        }
    }


}
