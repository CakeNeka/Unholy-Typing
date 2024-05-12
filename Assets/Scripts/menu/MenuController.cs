using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    [SerializeField] private GameObject settingsMenu;

    private void Start() {
        settingsMenu.SetActive(false);
    }

    public void Play() {
        SceneManager.LoadScene(1);
    }

    public void ShowSettings() {
        settingsMenu.SetActive(true);
    }

    public void HideSettings() {
        settingsMenu.SetActive(false);
    }
}