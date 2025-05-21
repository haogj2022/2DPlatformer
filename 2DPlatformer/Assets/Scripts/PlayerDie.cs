using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    public GameObject playerDie;
    public Vector2 respawnPosition = new Vector2(-4f, 0f);
    public float respawnDelay = 2f;

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
        gameObject.SetActive(false);
        Invoke("Respawn", respawnDelay);
    }

    private void Respawn()
    {
        gameObject.SetActive(true);
        gameObject.transform.position = respawnPosition;
    }
}
