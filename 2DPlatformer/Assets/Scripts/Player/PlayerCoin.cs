using TMPro;
using UnityEngine;

public class PlayerCoin : MonoBehaviour
{
    [SerializeField] private int coinValue = 1; // Value of the coin
    public TMP_Text coinText; // Reference to the UI text component
    private int coinCount = 0; // Total coins collected

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin")) // Check if the player collides with the coin
        {
            coinCount += coinValue; // Increment the coin count
            coinText.text = coinCount.ToString(); // Update the UI text with the coin value
            Destroy(collision.gameObject); // Destroy the coin object
        }
    }
}
