using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class RandomWordGenerator : MonoBehaviour {
    private string[] wimpWords;
    private string[] leetWords;

    public Word generateWord(DifficultyLevel difficulty) {
        if (difficulty == DifficultyLevel.Easy)
            return new Word(wimpWords[Random.Range(0, wimpWords.Length)], difficulty);
        return new Word(leetWords[Random.Range(0, leetWords.Length)], difficulty);
    }

    private void Start() {
        string wimpWordsFile = GameManager.Instance.config.wimpWordsFile;
        string leetWordsFile = GameManager.Instance.config.leetWordsFile;
        wimpWords = File.ReadAllLines(Application.streamingAssetsPath + "/" + wimpWordsFile);
        leetWords = File.ReadAllLines(Application.streamingAssetsPath + "/" + leetWordsFile);
        for (int i = 0; i < wimpWords.Length; i++) {
            wimpWords[i] = wimpWords[i].ToLower();
        }
        for (int i = 0; i < leetWords.Length; i++) {
            leetWords[i] = leetWords[i].ToLower();
        }

    }
}