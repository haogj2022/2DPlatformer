using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 9f;
    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Jump();
    }

    void Jump()
    {
        if (IsGrounded() && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        //add extra force if player hold down jump button
        else {
            if (Input.GetButton("Jump") && rb.velocity.y > 0)
            {
                rb.AddForce(Vector2.up * jumpForce * Time.deltaTime, ForceMode2D.Impulse);
            }
        }

        if (!IsGrounded())
        {
            anim.SetBool("Jump", true);
        }
        else
        {
            anim.SetBool("Jump", false);
        }
    }

    bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 1f, LayerMask.GetMask("Ground"));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyHead"))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
