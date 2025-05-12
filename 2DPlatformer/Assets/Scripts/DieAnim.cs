using UnityEngine;

public class DieAnim : MonoBehaviour
{
    private Rigidbody2D rb;
    private float jumpForce = 8f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
