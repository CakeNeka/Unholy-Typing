using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionManager : MonoBehaviour {
    private EntitySpawner spawner;
    private GameManager gameManager;
    private GameConfig config;

    private float averageCPM = 0f;
    private int wordNumber = 0;
    private bool canSpawnHardWord = true;

    private Dictionary<DifficultyLevel, float> baseSpeedDictionary;

    private float spawnDelayMultiplier = 1f; // changes based on time
    private float spawnDelayCPMMultiplier = 1f; // changes based on player's CPM

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
            Debug.Log(wordLevel);
            spawnedWord = spawner.SpawnWordGameObject(wordLevel);

            // set word fallspeed
            spawnedWord.FallSpeed = GenerateFallSpeed(wordLevel);

        }
    }
    private float CalculateSpawnDelay() {
        // the new value should be based on the time elapsed (Time.time) and the player's CPM
        float spawnDelay = config.initialSpawnDelay * spawnDelayMultiplier * spawnDelayCPMMultiplier;

        spawnDelayMultiplier -= 0.01f;

        // TODO: This should be a formula


        return spawnDelay;
    }

    IEnumerator WaitForHardWordCoolDown() {
        canSpawnHardWord = false;
        yield return new WaitForSeconds(config.hardWordCoolDown);
        canSpawnHardWord = true;
    }


    private DifficultyLevel GenerateDifficultyLevel() {
        Debug.Log(canSpawnHardWord);
        if (canSpawnHardWord && UnityEngine.Random.Range(0f, 1f) < config.hardWordChance) {
            StartCoroutine(WaitForHardWordCoolDown());
            return DifficultyLevel.Hard;
        }
        return DifficultyLevel.Easy;
    }

    private float GenerateFallSpeed(DifficultyLevel level) {
        // TODO:  Multipliers!!!
        return baseSpeedDictionary[level];
    }

    public void AddToAverageCPM(float cpm) {
        if (wordNumber == 0) {
            averageCPM = cpm;
        } else {
            float newSum = wordNumber * averageCPM + cpm;
            averageCPM = newSum / (wordNumber + 1);
        }
        wordNumber++;
    }
}
