using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    public ObjectPool objectPool;
    public float shootForce = 20f;

    public float shootInterval = 2f;
    private float shootTimer;

    void Start()
    {
        shootTimer = shootInterval;
    }

    void Update()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0)
        {
            Shoot();
            shootTimer = shootInterval;
        }
    }

    void Shoot()
    {
        GameObject cannonBall = objectPool.GetObject();
        cannonBall.transform.position = transform.position;
        cannonBall.transform.rotation = transform.rotation;
        Rigidbody2D rb = cannonBall.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;

        if (rb != null)
        {
            rb.AddForce(transform.right * shootForce, ForceMode2D.Impulse);
        }
    }
}
