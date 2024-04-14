using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName = "GameConfig", menuName = "UT/GameConfig", order = 0)]
[Serializable]
public class GameConfig : ScriptableObject {
    [Header("Random words text files")]
    public string wimpWordsFile;
    public string leetWordsFile;

    [Header("Game parameters")]
    public float initialSpawnDelay;
    public float easyFallSpeed;
    public float hardFallSpeed;
    [Tooltip("Between 0 and one")]
    [Min(0f)]
    public float hardWordChance;
    public float hardWordCoolDown;

    [Header("Multipliers")]
    public List<Interval> CPMIntervals;

}