using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;

/// <summary>
/// There is one for every active word
/// Responsible for displaying and moving a single word
/// </summary>
public class WordController : MonoBehaviour {

    private float startTime;
    private float secondsElapsed = 0f;

    private string styleSelectedOpen = "<style=\"Selected\">";
    private string styleSelectedClose = "</style>";
    private string styleTypedOpen = "<style=\"typed\">";
    private string styleTypedClose = "</style>";
    private int index = 0; // Number of letters already typed in this word
    private Word word = Word.defaultWord;
    private TMP_Text displayText;

    public int StrokesMissed { get; private set; } = 0;
    public float FallSpeed { get; set; } = 1f; // to be set by GameManager / ProgressManager...
    public bool TimerRunning { get; private set; } = false;

    private void Awake() {
        displayText = GetComponent<TMP_Text>();
    }

    private void Start() {
        Theme theme = GameManager.Instance.Theme;
        displayText.color = theme.foreground;

        styleTypedOpen += $"<color=#{theme.foregroundTyped.ToHexString()}>";
        styleTypedClose = "</color>" + styleTypedClose;
    }

    private void Update() {
        transform.Translate(0f, -FallSpeed * Time.deltaTime, 0);
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
        string newText = 
            $"{styleSelectedOpen}{styleTypedOpen}{word.text.Substring(0, index)}{styleTypedClose}{word.text.Substring(index)}{styleSelectedClose}";

        displayText.text = newText;
    }

    public void DestroySelf() {
        Destroy(gameObject);
    }

    public bool WordTyped() {
        return word.text.Length == index;
    }

    public void ToggleTimer() {
        if (TimerRunning) {
            secondsElapsed += Time.time - startTime;
            string newText = $"{styleTypedOpen}{word.text.Substring(0, index)}{styleTypedClose}{word.text.Substring(index)}";
            displayText.text = newText;
        } else {
            startTime = Time.time;
        }
        TimerRunning = !TimerRunning;
    }

    public float GetSecondsElapsed() {
        Assert.IsFalse(TimerRunning);
        return secondsElapsed;
    }

    public string GetWordString() {
        return word.text;
    }

    public void AddMiss() {
        StrokesMissed++;
    }
}