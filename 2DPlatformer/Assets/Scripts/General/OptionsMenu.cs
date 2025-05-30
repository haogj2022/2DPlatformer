using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public Animator optionsMenu;
    public Animator transition;

    public void OpenOptions()
    {
        optionsMenu.SetTrigger("Open");
    }

    public void CloseOptions()
    {
        optionsMenu.SetTrigger("Close");
    }

    public void MainMenu()
    {
        transition.SetTrigger("Play");
        Invoke("LoadMainMenu", 1f); // Wait for the animation to finish before loading the scene
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
