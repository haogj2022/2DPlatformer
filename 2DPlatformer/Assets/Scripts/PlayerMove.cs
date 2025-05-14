using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 4f;
    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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

        if (moveInput != 0 && rb.velocity.y == 0)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
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
