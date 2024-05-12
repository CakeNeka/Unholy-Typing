using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SettingsMenu : MonoBehaviour {
    [SerializeField] private TMP_Dropdown themesDropdown;
    List<string> stringThemes;

    private void Start() {
        themesDropdown.ClearOptions();
        stringThemes = Themes.GetThemeNames();
        themesDropdown.AddOptions(stringThemes);
    }

    public void HandleThemeChange(int val) {
        Theme selectedTheme = Themes.GetTheme(stringThemes[val]);
        Debug.Log($"Selected theme: {selectedTheme}");
        GameManager.selectedTheme = selectedTheme;
    }
}