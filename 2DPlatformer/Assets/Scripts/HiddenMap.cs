using UnityEngine;
using UnityEngine.Tilemaps;

public class HiddenMap : MonoBehaviour
{
    private TilemapRenderer tilemapRenderer;

    void Start()
    {
        // Get the TilemapRenderer component attached to this GameObject
        tilemapRenderer = GetComponent<TilemapRenderer>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Disable the game object when the player enters the trigger
            tilemapRenderer.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Enable the game object when the player exits the trigger
            tilemapRenderer.enabled = true;
        }
    }
}
