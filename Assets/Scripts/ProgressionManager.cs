using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionManager : MonoBehaviour {
    [SerializeField]
    private float averageCPM = 0;
    private int wordNumber = 0;
    public void addToAverageCPM(float cpm) {
        if (wordNumber == 0) {
            averageCPM = cpm;
        } else {
            float newSum = wordNumber * averageCPM + cpm;
            averageCPM = newSum / (wordNumber + 1);
        }
        wordNumber++;
    }
}
