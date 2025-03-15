using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {
    public GameObject menuCanvas;
    public GameObject creditsCanvas;
    private bool creditsActive;
    void Awake() {
        creditsActive = false;
    }
    public void StartGame() {
        SceneManager.LoadScene(1);
    }
    public void ToggleCredits() {
        creditsActive = !creditsActive;
        if (creditsActive) {
            menuCanvas.SetActive(false);
            creditsCanvas.SetActive(true);
        } else {
            menuCanvas.SetActive(true);
            creditsCanvas.SetActive(false);
        }
    }
    public void Exit() {
        Application.Quit();
    }
}
