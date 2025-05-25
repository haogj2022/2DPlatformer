using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void StartGame()
    {
        anim.SetTrigger("Play");
        Invoke("LoadGame", 2f); // Wait for the animation to finish before loading the scene
    }

    private void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
}
