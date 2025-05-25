using UnityEngine;
using UnityEngine.SceneManagement;

public class Story : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
