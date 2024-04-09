using UnityEngine;

[CreateAssetMenu(fileName = "WordGenerator", menuName = "TMPWordGenerator", order = 0)]
public class RandomWordGenerator : ScriptableObject {
    public Word generateWord(DifficultyLevel difficulty) {
        return new Word(difficulty.ToString(), difficulty);
        // TODO Actually generate a random word given difficulty level
    }
}