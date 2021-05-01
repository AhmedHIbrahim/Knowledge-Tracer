using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{

    public GameObject gameCanvas;
    public GameObject menuCanvas;
    public GameObject TileManager;


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        // if game running
        if (Time.timeScale == 1)
        {
            TileManager.GetComponent<SoundManager>().PauseSound();
            gameCanvas.SetActive(false);
            menuCanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ResumeGame()
    {
        // if game paused
        if (Time.timeScale == 0)
        {
            TileManager.GetComponent<SoundManager>().ResumeSound();
            menuCanvas.SetActive(false);
            gameCanvas.SetActive(true);
            Time.timeScale = 1;
        }
    }


    public void ExitGame()
    {
        Debug.Log("ExitGame Pressed");
        Application.Quit();
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
