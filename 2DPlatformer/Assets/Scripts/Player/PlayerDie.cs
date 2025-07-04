using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    public GameObject playerDie;
    public DeathMenu deathMenu;
    private Vector2 respawnPosition;

    private void Start()
    {
        respawnPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Die();
        }

        if (other.CompareTag("Checkpoint"))
        {
            other.GetComponent<Animator>().SetTrigger("Activate");
            SaveGame();
        }
    }

    private void SaveGame()
    {
        respawnPosition = transform.position;
    }

    void Die()
    {
        Instantiate(playerDie, transform.position, Quaternion.identity);
        deathMenu.Show();
        gameObject.SetActive(false);
        Invoke("Respawn", 4f);
    }

    private void Respawn()
    {
        gameObject.SetActive(true);
        gameObject.transform.position = respawnPosition;
    }
}
