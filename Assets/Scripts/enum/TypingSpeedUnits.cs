using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

public class TypingSpeedUnits {
    private static Dictionary<string, TypingSpeedUnit> units = new Dictionary<string, TypingSpeedUnit> {
        ["cpm"] = new TypingSpeedUnit("Characters per minute", "CPM", 1f),
        ["wpm"] = new TypingSpeedUnit("Words per minute", "WPM", 0.2f),
    };

    public static TypingSpeedUnit getUnit(string typingSpeedUnitString) {
        return units.ContainsKey(typingSpeedUnitString) ?
            units[typingSpeedUnitString]
            :
            units["cpm"];
        
    }
}