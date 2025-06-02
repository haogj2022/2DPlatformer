using UnityEngine;
using UnityEngine.SceneManagement;

public class Story : MonoBehaviour
{
    public GameObject skipButton;

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // show skip button after 2 seconds
    private void Start()
    {
        Invoke("ShowSkipButton", 2f);
    }

    private void ShowSkipButton()
    {
        skipButton.SetActive(true);
    }
}
