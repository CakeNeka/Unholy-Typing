using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject mainMenu;

    private void Start() {
        settingsMenu.SetActive(false);
    }

    public void Play() {
        SceneManager.LoadScene(1);
    }

    public void ShowSettings() {
        settingsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void HideSettings() {
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void QuitGame() {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}