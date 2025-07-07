using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedMenu : MonoBehaviour
{
    public GameObject pausedPanel;
    public Animator transition;
    private float delay = 1f;

    public void Paused()
    {
        Time.timeScale = 0;
        pausedPanel.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        pausedPanel.SetActive(false);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        transition.SetTrigger("Play");
        Invoke("LoadMainMenu", delay);
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void NextLevel()
    {
        Time.timeScale = 1;
        LevelManager levelManager = FindObjectOfType<LevelManager>();
        levelManager.selectedLevel++;
        levelManager.SelectLevel(levelManager.selectedLevel);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
