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
    }

    void Die()
    {
        Instantiate(playerDie, transform.position, Quaternion.identity);
        playerDie.transform.localScale = gameObject.transform.localScale;
        gameObject.SetActive(false);
        Invoke("Respawn", respawnDelay);
    }

    private void Respawn()
    {
        gameObject.SetActive(true);
        gameObject.transform.position = respawnPosition;
    }
}
