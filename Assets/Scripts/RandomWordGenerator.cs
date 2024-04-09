using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RandomWordGenerator : MonoBehaviour {
    [SerializeField]
    private static string unholyTextFile = "unholy.txt";
    private static string[] unholyWords;

    public Word generateWord(DifficultyLevel difficulty) {
        // difficulty levels are not yet implemented
        return new Word(unholyWords[Random.Range(0, unholyWords.Length)], difficulty);
    }

    private void Start() {
        unholyWords = File.ReadAllLines(Application.streamingAssetsPath + "/" + unholyTextFile);
    }
}