using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Flip();
    }

    void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    void Flip()
    {
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Flip the player to face right
        }
        else if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Flip the player to face left
        }
    }
}
