using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RandomWordGenerator : MonoBehaviour {
    // TODO txt filenames should be managed by GameManager.GameParameters
    [SerializeField]
    private static string wimpWordsFile = "wimp.txt";
    [SerializeField]
    private static string leetWordsFile = "leet.txt";
    private string[] wimpWords;
    private string[] leetWords;

    public Word generateWord(DifficultyLevel difficulty) {
        if (difficulty == DifficultyLevel.Wimp)
            return new Word(wimpWords[Random.Range(0, wimpWords.Length)], difficulty);
        return new Word(leetWords[Random.Range(0, leetWords.Length)], difficulty);
    }

    private void Start() {
        wimpWords = File.ReadAllLines(Application.streamingAssetsPath + "/" + wimpWordsFile);
        leetWords = File.ReadAllLines(Application.streamingAssetsPath + "/" + leetWordsFile);
    }
}