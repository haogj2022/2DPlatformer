using UnityEngine;
using UnityEngine.SceneManagement;

public class Story : MonoBehaviour
{
    public GameObject skipButton;
    private float delay = 2f;

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void Start()
    {
        Invoke("ShowSkipButton", delay);
    }

    private void ShowSkipButton()
    {
        skipButton.SetActive(true);
    }
}
