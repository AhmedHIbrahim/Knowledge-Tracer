using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public GameObject tileManager;

    public GameObject gameCanvas;
    public GameObject menuCanvas;
    public GameObject pauseMenu;
    public GameObject gameOverPanel;
    public TextMeshProUGUI yourScoreBody;
    public TextMeshProUGUI highestScoreBody;
    int highestScore = 0;

    void Start()
    {
        highestScore = PlayerPrefs.GetInt("HighestScore", 0);
    }

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
            tileManager.GetComponent<SoundManager>().PauseSound();
            gameCanvas.SetActive(false);
            menuCanvas.SetActive(true);
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ResumeGame()
    {
        // if game paused
        if (Time.timeScale == 0)
        {
            tileManager.GetComponent<SoundManager>().ResumeSound();
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

    public void GameOver()
    {

        int score = tileManager.GetComponent<QuestionAnswerManager>().GetScore();
        PauseGame();
        pauseMenu.SetActive(false);
        gameOverPanel.SetActive(true);
        yourScoreBody.text = score.ToString();
        highestScoreBody.text = highestScore.ToString();

        if (score > highestScore)
        {
            highestScore = score;
            PlayerPrefs.SetInt("HighestScore", highestScore);
        }

    }

}
