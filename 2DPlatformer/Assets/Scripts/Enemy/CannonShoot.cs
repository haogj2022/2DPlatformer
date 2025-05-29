using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    public ObjectPool objectPool;
    public float shootForce = 20f;

    public float shootInterval = 2f;
    private float shootTimer;

    private Rigidbody2D cannonBodyRb;

    void Start()
    {
        shootTimer = shootInterval;
        cannonBodyRb = GetComponentInParent<Rigidbody2D>();
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
        cannonBall.tag = "Enemy";
        Rigidbody2D cannonBallRb = cannonBall.GetComponent<Rigidbody2D>();
        cannonBallRb.velocity = Vector2.zero;

        if (cannonBallRb != null)
        {
            cannonBallRb.AddForce(transform.right * shootForce, ForceMode2D.Impulse);
            //add force to the cannon itself
            cannonBodyRb.AddForce(-transform.right * shootForce * 0.5f, ForceMode2D.Impulse);
        }
    }
}
