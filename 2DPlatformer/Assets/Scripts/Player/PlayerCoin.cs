using TMPro;
using UnityEngine;

public class PlayerCoin : MonoBehaviour
{
    [SerializeField] private int coinValue = 1;
    public TMP_Text coinText;

    [HideInInspector]
    public int coinCount = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin")) 
        {
            coinCount += coinValue; 
            coinText.text = coinCount.ToString(); 
            Destroy(collision.gameObject);
        }
    }
}
