using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionManager : MonoBehaviour {
    private EntitySpawner spawner;
    private GameManager gameManager;
    private GameConfig config;

    [SerializeField] // Just for debugging
    private float averageCPM = 0f;
    private int wordNumber = 0; // number of words already typed
    private bool canSpawnHardWord = true;
    private int currentMisses = 0;

    private Dictionary<DifficultyLevel, float> baseSpeedDictionary;

    private float spawnDelayTimedMultiplier = 1f; // changes based on time

    private void Start() {
        spawner = GetComponent<EntitySpawner>();
        gameManager = GameManager.Instance;
        config = gameManager.config;
        baseSpeedDictionary = new Dictionary<DifficultyLevel, float> {
            [DifficultyLevel.Easy] = config.easyFallSpeed,
            [DifficultyLevel.Hard] = config.hardFallSpeed,
        };

        StartCoroutine(SpawnRepeating());
    }

    IEnumerator SpawnRepeating() {
        while (gameManager.IsGameActive) {
            WordController spawnedWord;
            DifficultyLevel wordLevel;
            // wait spawn delay
            yield return new WaitForSeconds(CalculateSpawnDelay());

            // decide whether to generate hard or easy word
            wordLevel = GenerateDifficultyLevel();
            spawnedWord = spawner.SpawnWordGameObject(wordLevel);

            // set word fallspeed
            spawnedWord.FallSpeed = GenerateFallSpeed(wordLevel);
        }
    }
    private float CalculateSpawnDelay() {
        float spawnDelay = config.initialSpawnDelay
            * spawnDelayTimedMultiplier
            * gameManager.getCPMSpawnDelayMultiplier(averageCPM);

        spawnDelayTimedMultiplier *= gameManager.config.spawnDelayTimedPercentage;

        return spawnDelay;
    }

    IEnumerator WaitForHardWordCoolDown() {
        canSpawnHardWord = false;
        yield return new WaitForSeconds(config.hardWordCoolDown);
        canSpawnHardWord = true;
    }


    private DifficultyLevel GenerateDifficultyLevel() {
        if (canSpawnHardWord && UnityEngine.Random.Range(0f, 1f) < config.hardWordChance) {
            StartCoroutine(WaitForHardWordCoolDown());
            return DifficultyLevel.Hard;
        }
        return DifficultyLevel.Easy;
    }

    private float GenerateFallSpeed(DifficultyLevel level) {
        return baseSpeedDictionary[level] * gameManager.GetCPMFallSpeedMultiplier(averageCPM);
    }

    public void AddToAverageCPM(float cpm) {
        if (wordNumber == 0) {
            averageCPM = cpm;
        } else {
            // It calculates the new avg based on the previous avg, the new value and the amount of values.
            float newSum = wordNumber * averageCPM + cpm;
            averageCPM = newSum / (wordNumber + 1);
        }
        wordNumber++;
    }

    public void MissWord() {
        if (currentMisses++ > gameManager.config.missesAllowed) {
            Debug.LogWarning("TODO: You just lose, this is very very bad...");
        }
        Debug.Log($"Current misses: {currentMisses}");
    }
}
