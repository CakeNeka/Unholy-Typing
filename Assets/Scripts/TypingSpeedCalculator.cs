using System.Collections.Generic;

public class TypingSpeedCalculator {

    private List<WordCPM> typedWords = new List<WordCPM>();
    private float runningAverageCPM = 0f;
    private float last10RunningAverageCPM = 0f;
    public float AverageCPM {
        get {
            return runningAverageCPM;
        }
    }
    public float AverageCPMLast10 {
        get {
            return last10RunningAverageCPM;
        }
    }


    public void AddWordCPM(WordCPM wordSpeed) {
        AddToRunningAverage(wordSpeed.cpm);
        AddToLast10RunningAverage(wordSpeed.cpm);
        typedWords.Add(wordSpeed);
    }

    private void AddToRunningAverage(float cpm) {
        if (typedWords.Count == 0) {
            runningAverageCPM = cpm;
        } else {
            // It calculates the new avg based on the previous avg, the new value and the amount of values.
            float newSum = typedWords.Count * runningAverageCPM + cpm;
            runningAverageCPM = newSum / (typedWords.Count + 1);
        }
    }

    private void AddToLast10RunningAverage(float cpm) {
        if (typedWords.Count == 0) {
            last10RunningAverageCPM = cpm;
        } else if (typedWords.Count < 10) {
            float newSum = typedWords.Count * last10RunningAverageCPM + cpm;
            last10RunningAverageCPM = newSum / (typedWords.Count + 1);
        } else {
            float avgToRemove = typedWords[typedWords.Count - 9].cpm;
            float newSum = (10 * last10RunningAverageCPM) - avgToRemove + cpm;
            last10RunningAverageCPM = newSum / 10;
        }
    }
}