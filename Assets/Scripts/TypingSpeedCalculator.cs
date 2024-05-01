using System;
using System.Collections.Generic;
using System.Linq;

public class TypingSpeedCalculator {

    private List<WordCPM> typedWords = new List<WordCPM>();
    public float AverageCPM {
        get {
            return typedWords.Count() > 0 ?
                typedWords.Select(c => c.cpm).Average()
                :
                0f;
        }
    }

    public float AverageCPMLast10 {
        get {
            return typedWords.Count() > 0 ?
                // average of the last 10 elements of the list
                typedWords.Skip(Math.Max(0, typedWords.Count() - 10)).Select(c => c.cpm).Average()
                :
                0f;
        }
    }

    public void AddWordCPM(WordCPM wordSpeed) {
        typedWords.Add(wordSpeed);
    }
}