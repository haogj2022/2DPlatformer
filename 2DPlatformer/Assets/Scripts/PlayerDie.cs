using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour
{
    public GameObject playerDie;
    private float delay = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Die();
        }
    }

    void Die()
    {
        playerDie.transform.position = transform.position;
        playerDie.transform.localScale = transform.localScale;
        playerDie.SetActive(true);
        gameObject.SetActive(false);
        Invoke("ReloadScene", delay);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
