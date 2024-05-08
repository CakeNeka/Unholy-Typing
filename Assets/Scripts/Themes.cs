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

    public static readonly Theme neon = new(
        background: getColor("#00002e"),
        foreground: getColor("#f1deef"),
        foregroundTyped: getColor("#ff3d8b"),
        foregroundUI: getColor("#8fecff")
    );

    public static readonly Theme darling = new(
        background: getColor("#fec8cd"),
        foreground: getColor("#ffffff"),
        foregroundTyped: getColor("#a30000"),
        foregroundUI: getColor("#2e7dde")
    );
}