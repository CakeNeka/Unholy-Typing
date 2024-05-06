using UnityEngine;

public class Themes {
    private static Color getColor(string hexColor) {
        if (ColorUtility.TryParseHtmlString(hexColor, out Color color)) {
            return color;
        }
        return Color.black;
    }

    public static readonly Theme serikaDark = new(
        background: getColor("#323437"),
        foreground: getColor("#d1d0c5"),
        foregroundTyped: getColor("#e2b714"),
        foregroundUI: getColor("#ca4754")
    );

    public static readonly Theme vscode = new(
        background: getColor("#1e1e1e"),
        foreground: getColor("#d4d4d4"),
        foregroundTyped: getColor("#007acc"),
        foregroundUI: getColor("#f44747")
    );
}