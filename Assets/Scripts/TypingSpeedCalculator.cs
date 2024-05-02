using System;
using System.Collections.Generic;
using System.Linq;

public class TypingSpeedCalculator {

    private List<WordCPM> typedWords = new List<WordCPM>();
    public float AverageCPM {
        get {
            return CalculateTypingSpeedUnit(
                typedWords.Select(c => c.word.Count()).Sum(),
                typedWords.Select(c => c.seconds).Sum()
            );
        }
    }

    public float AverageCPMLast10 {
        get {
            if (typedWords.Count() <= 10)
                return AverageCPM;

            return CalculateTypingSpeedUnit(
                typedWords.TakeLast(10).Select(c => c.word.Count()).Sum(),
                typedWords.TakeLast(10).Select(c => c.seconds).Sum()
            );
        }
    }

    public void AddWordCPM(WordCPM wordSpeed) {
        typedWords.Add(wordSpeed);
    }

    private float CalculateTypingSpeedUnit(int characters, float secondsElapsed) {
        return characters / (secondsElapsed / 60) * GameManager.Instance.config.speedUnit.CpmConversionFactor;
    }
}