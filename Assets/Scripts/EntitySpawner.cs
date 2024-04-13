using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class EntitySpawner : MonoBehaviour {

    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private GameObject wordPrefab;
    private RandomWordGenerator wordGenerator;

    private void Start() {
        wordGenerator = GetComponent<RandomWordGenerator>();
        gameManager = GameManager.Instance;
        StartCoroutine(SpawnRepeating());
    }

    // TODO: Progression manager should control when a word is spawned
    IEnumerator SpawnRepeating() {
        int i = 0;
        while (true) {
            yield return new WaitForSeconds(2f);
            if (i++ % 2 == 0)
                SpawnWordGameObject(DifficultyLevel.Wimp);
            else
                SpawnWordGameObject(DifficultyLevel.Leet);
        }
    }

    public void SpawnWordGameObject(DifficultyLevel difficulty) {
        // generate random word
        Word word = wordGenerator.generateWord(difficulty);
        // Instantiate word GO
        WordController controller = Instantiate(wordPrefab, GenerateSpawnPosition(difficulty), Quaternion.identity).GetComponent<WordController>();
        controller.SetWord(word);
        gameManager.AddWordController(controller);
    }

    /// <summary>
    /// Generates a random position, y coordinate slightly above screen
    /// and x coordinate between camera bounds
    /// Hard words will always spawn in the center
    /// </summary>
    private Vector3 GenerateSpawnPosition(DifficultyLevel difficulty) {
        Camera cam = Camera.main;

        float offsetX = 2f; // FIXME: this hardcoded value should be based on the word's max width
        float offsetY = 2f;
        Vector3 topLeftCorner = cam.ViewportToWorldPoint(new Vector3(0, 1, cam.nearClipPlane));
        Vector3 topRightCorner = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane));

        float xCoord = difficulty == DifficultyLevel.Wimp ?
            Random.Range(topRightCorner.x - offsetX, topLeftCorner.x + offsetX)
            :
            (topLeftCorner.x + topRightCorner.x) / 2;
        xCoord = topLeftCorner.x + offsetX;

        float yCoord = topRightCorner.y + offsetY;

        return new Vector3(xCoord, yCoord);
    }

}
