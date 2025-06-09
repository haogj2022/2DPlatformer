using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public Animator optionsMenu;
    public Animator transition;
    private float delay = 1f;

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
        Invoke("LoadMainMenu", delay);
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
