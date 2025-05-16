using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    public GameObject coin;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(coin, transform.position, Quaternion.identity);
            Destroy(gameObject); // Destroy the enemy game object
        }
    }
}
