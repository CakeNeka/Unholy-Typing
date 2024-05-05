using UnityEngine;

public struct Theme {
    public Color background;
    public Color foreground;
    public Color foregroundTyped;
    public Color foregroundUI;

    public Theme(Color background, Color foreground, Color foregroundTyped, Color foregroundUI) {
        this.background = background;
        this.foreground = foreground;
        this.foregroundTyped = foregroundTyped;
        this.foregroundUI = foregroundUI;
    }
}