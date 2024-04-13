using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RandomWordGenerator : MonoBehaviour {
    [SerializeField]
    private static string wimpWordsFile = "wimp.txt";
    [SerializeField]
    private static string leetWordsFile = "leet.txt";
    private static string[] wimpWords;
    private static string[] leetWords;

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