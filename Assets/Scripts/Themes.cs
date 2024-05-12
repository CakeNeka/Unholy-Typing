using System.Collections.Generic;
using UnityEngine;

public class Themes {
    private static Color getColor(string hexColor) {
        if (ColorUtility.TryParseHtmlString(hexColor, out Color color)) {
            return color;
        }
        return Color.black;
    }


    public static readonly Theme serikaDark = new(
        name: "Serika Dark",
        background: getColor("#323437"),
        foreground: getColor("#d1d0c5"),
        foregroundTyped: getColor("#e2b714"),
        foregroundUI: getColor("#ca4754")
    );

    public static readonly Theme vscode = new(
        name: "VsCode",
        background: getColor("#1e1e1e"),
        foreground: getColor("#d4d4d4"),
        foregroundTyped: getColor("#007acc"),
        foregroundUI: getColor("#f44747")
    );

    public static readonly Theme neon = new(
        name: "Neon",
        background: getColor("#00002e"),
        foreground: getColor("#f1deef"),
        foregroundTyped: getColor("#ff3d8b"),
        foregroundUI: getColor("#8fecff")
    );

    public static readonly Theme darling = new(
        name: "Darling",
        background: getColor("#fec8cd"),
        foreground: getColor("#ffffff"),
        foregroundTyped: getColor("#a30000"),
        foregroundUI: getColor("#2e7dde")
    );

    private static Dictionary<string, Theme> themes = new Dictionary<string, Theme> {
        [serikaDark.name] = serikaDark,
        [vscode.name] = vscode,
        [neon.name] = neon,
        [darling.name] = darling,
    };

    public static List<string> GetThemeNames() {
        return new List<string>(themes.Keys);
    }

    public static Theme GetTheme(string themeName) {
        return themes.GetValueOrDefault(themeName, serikaDark);
    }
}