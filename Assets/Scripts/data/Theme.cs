using System;
using UnityEngine;

public class Theme {

    public string name;
    public Color background;
    public Color foreground;
    public Color foregroundTyped;
    public Color foregroundUI;

    public Theme(Color background, Color foreground, Color foregroundTyped, Color foregroundUI, string name) {
        this.background = background;
        this.foreground = foreground;
        this.foregroundTyped = foregroundTyped;
        this.foregroundUI = foregroundUI;
        this.name = name;
    }
}