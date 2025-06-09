using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator levelMenu;
    public Animator transition;
    public LevelManager gameManager;
    private bool canSelectLevel = true;
    private float delay = 1f;

    public void SelectLevel(int levelIndex)
    {
        if (levelIndex > 0 && canSelectLevel)
        {
            canSelectLevel = false;
            gameManager.SelectLevel(levelIndex - 1);
            transition.SetTrigger("Play");
            Invoke("LoadGame", delay);
        }
    }

    public void StartGame()
    {
        levelMenu.SetTrigger("Open");
    }

    public void GoBack()
    {
        levelMenu.SetTrigger("Close");
    }

    private void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
}
