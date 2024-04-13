using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GameConfig", menuName = "UT/GameConfig", order = 0)]
[Serializable]
public class GameConfig : ScriptableObject {
    [Header("Random words text files")]
    public string wimpWordsFile;
    public string leetWordsFile;


}