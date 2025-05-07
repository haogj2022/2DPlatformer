using UnityEngine;

public class DieAnim : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * 8, ForceMode2D.Impulse);
    }
}
