using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator mainMenu;
    public Animator transition;
    public LevelManager levelManager;
    private bool canSelectLevel = true;
    private float delay = 1f;

    public void IndexLevel(int levelIndex)
    {
        if (canSelectLevel)
        {
            canSelectLevel = false;
            levelManager.SelectLevel(levelIndex);
            transition.SetTrigger("Play");
            Invoke("LoadGame", delay);
        }
    }

    public void OpenLevel()
    {
        mainMenu.SetTrigger("OpenLevel");
    }

    public void OpenOptions()
    {
        mainMenu.SetTrigger("OpenOptions");
    }

    public void CloseLevel()
    {
        mainMenu.SetTrigger("CloseLevel");
    }

    public void CloseOptions()
    {
        mainMenu.SetTrigger("CloseOptions");
    }

    private void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
}
