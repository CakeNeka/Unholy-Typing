using System.IO;
using UnityEngine;

public class RandomWordGenerator : MonoBehaviour {
    private string[] easyWords;
    private string[] hardWords;

    public Word generateWord(DifficultyLevel difficulty) {
        if (difficulty == DifficultyLevel.Easy)
            return new Word(easyWords[Random.Range(0, easyWords.Length)], difficulty);
        return new Word(hardWords[Random.Range(0, hardWords.Length)], difficulty);
    }

    private void Start() {
        string easyWordsFile = GameManager.Instance.config.easyWordsFile;
        string hardWordsFile = GameManager.Instance.config.hardWordsFile;
        easyWords = File.ReadAllLines(Application.streamingAssetsPath + "/" + easyWordsFile);
        hardWords = File.ReadAllLines(Application.streamingAssetsPath + "/" + hardWordsFile);
        for (int i = 0; i < easyWords.Length; i++) {
            easyWords[i] = easyWords[i].ToLower();
        }
        for (int i = 0; i < hardWords.Length; i++) {
            hardWords[i] = hardWords[i].ToLower();
        }

    }
}