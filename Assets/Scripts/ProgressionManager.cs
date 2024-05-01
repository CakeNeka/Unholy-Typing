using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionManager : MonoBehaviour {
    private EntitySpawner spawner;
    private GameManager gameManager;
    private GameConfig config;

    TypingSpeedCalculator speedCalculator;

    private bool canSpawnHardWord = true;
    private int currentMisses = 0;

    private Dictionary<DifficultyLevel, float> baseSpeedDictionary;

    private float spawnDelayTimedMultiplier = 1f; // changes based on time

    private void Start() {
        speedCalculator = new TypingSpeedCalculator();
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
            // wait for spawn delay
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
            * gameManager.getCPMSpawnDelayMultiplier(speedCalculator.AverageCPMLast10);

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
        return baseSpeedDictionary[level] * gameManager.GetCPMFallSpeedMultiplier(speedCalculator.AverageCPMLast10);
    }

    public void AddToAverageCPM(string word, float cpm) {
        speedCalculator.AddWordCPM(new WordCPM(word, cpm));
        gameManager.UIManager.setAverageCPMText(speedCalculator.AverageCPM);
        gameManager.UIManager.setAverageCPMLast10Text(speedCalculator.AverageCPMLast10);
    }

    public void MissWord() {
        if (currentMisses++ > gameManager.config.missesAllowed) {
            gameManager.GameOver();
        }
        Debug.Log($"Current misses: {currentMisses}");
    }
}
