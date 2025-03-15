using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject[] buttons;
    private bool paused = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    public void TogglePauseMenu()
    {
        paused = !paused;
        if (paused)
        {
            Time.timeScale = 0;
        } 
        else
        {
            Time.timeScale = 1;
        }
        foreach (GameObject button in buttons)
        {
            button.SetActive(paused);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
