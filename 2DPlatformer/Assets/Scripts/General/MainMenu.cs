using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator levelMenu;
    public Animator transition;
    public GameManager gameManager;
    private bool canSelectLevel = true;

    public void SelectLevel(int levelIndex)
    {
        if (levelIndex > 0 && canSelectLevel)
        {
            canSelectLevel = false;
            gameManager.SelectLevel(levelIndex - 1); // Adjusting for zero-based index
            transition.SetTrigger("Play");
            Invoke("LoadGame", 1f); // Wait for the animation to finish before loading the scene
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
