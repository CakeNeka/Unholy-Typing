[System.Serializable]
public class ScoreEntry {
    public string name;
    public int score;
    public float averageSpeed;
    public float accuracy;
    public int wordsTyped;

    public ScoreEntry(string name, int score) {
        this.name = name;
        this.score = score;
    }
}