using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
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
    }

    void Flip()
    {
        if (rb.velocity.x > 0)
        {
            anim.SetBool("Run", true); // Set the running animation
            transform.localScale = new Vector3(-1, 1, 1); // Flip the player to face right
        }
        else if (rb.velocity.x < 0)
        {
            anim.SetBool("Run", true); // Set the running animation
            transform.localScale = new Vector3(1, 1, 1); // Flip the player to face left
        }
        else
        {
            anim.SetBool("Run", false); // Set the idle animation
        }
    }
}
