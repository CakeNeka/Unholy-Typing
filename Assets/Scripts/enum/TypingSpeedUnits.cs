using System.Collections.Generic;

public class TypingSpeedUnits {
    public static Dictionary<string, TypingSpeedUnit> units = new Dictionary<string, TypingSpeedUnit> {
        ["CPM"] = new TypingSpeedUnit("Characters per minute", "CPM", 1f),
        ["WPM"] = new TypingSpeedUnit("Words per minute", "WPM", 0.2f),
    };
}