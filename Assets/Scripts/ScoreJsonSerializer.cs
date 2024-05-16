using System.Collections.Generic;
using UnityEngine;

public class ScoreJsonSerializer {
    public List<ScoreEntry> LoadScoresFromJson() {
        if (PlayerPrefs.HasKey("scores")) {
            return JsonUtility.FromJson<List<ScoreEntry>>(PlayerPrefs.GetString("Scores"));
        }

        return new List<ScoreEntry>();
    }    

    public void SaveScoresToJson(List<ScoreEntry> scores) {
        string json = JsonUtility.ToJson(scores);
        PlayerPrefs.SetString("scores", json);
    }

}