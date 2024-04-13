using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

/// <summary>
/// There is one for every active word
/// Responsible for displaying and moving a single word
/// </summary>
public class WordController : MonoBehaviour {

    private float startTime;
    private float elapsedTime = 0f;
    private bool timerRunning = false;

    private string styleOpen = "<style=\"typed\">";
    private string styleClose = "</style>";
    private int index = 0; // Number of letters already typed in this word
    private Word word = Word.defaultWord;
    private TMP_Text displayText;
    public float fallSpeed { get; set; } = 1f; // to be set by GameManager / ProgressManager...

    private void Awake() {
        displayText = GetComponent<TMP_Text>();
    }

    private void Update() {
        transform.Translate(0f, -fallSpeed * Time.deltaTime, 0);
    }

    public void SetWord(Word word) {
        this.word = word;
        displayText.text = word.text;
    }

    public bool IsNextLetter(char letter) {
        return letter == word.text[index];
    }

    public void TypeLetter() {
        index++;
        Assert.IsFalse(index > word.text.Length);

        // add rich text tags
        string newText = styleOpen + word.text.Substring(0, index) + styleClose + word.text.Substring(index);
        displayText.text = newText;
    }

    public void DestroySelf() {
        Destroy(gameObject);
    }

    public bool WordTyped() {
        return word.text.Length == index;
    }

    public void ToggleTimer() {
        if (timerRunning) {
            elapsedTime += Time.time - startTime;
        } else {
            startTime = Time.time;
        }
        timerRunning = !timerRunning;
    }

    public float getCPM() {
        Assert.IsFalse(timerRunning);
        return word.text.Length / (elapsedTime / 60f);
    }
}