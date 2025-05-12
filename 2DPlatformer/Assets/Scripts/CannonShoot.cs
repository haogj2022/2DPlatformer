using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    public GameObject cannonBallSpawn;
    public ObjectPool objectPool;
    public float shootForce = 10f;

    public float shootInterval = 2f;
    private float shootTimer;
    public float shootDuration = 1f;
    private float shootDurationTimer;
    public bool isShooting = false;

    void Start()
    {
        shootTimer = shootInterval;
        shootDurationTimer = shootDuration;
    }

    void Update()
    {
        if (isShooting)
        {
            shootDurationTimer -= Time.deltaTime;
            if (shootDurationTimer <= 0)
            {
                isShooting = false;
                shootDurationTimer = shootDuration;
            }
        }
        else
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0)
            {
                Shoot();
                shootTimer = shootInterval;
            }
        }
    }

    void Shoot()
    {
        GameObject cannonBall = objectPool.GetObject();
        cannonBall.transform.position = cannonBallSpawn.transform.position;
        cannonBall.transform.rotation = cannonBallSpawn.transform.rotation;
        Rigidbody2D rb = cannonBall.GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.zero;
        if (rb != null)
        {
            Vector2 shootDirection = (cannonBallSpawn.transform.position - transform.position).normalized;
            rb.AddForce(shootDirection * shootForce, ForceMode2D.Impulse);
        }
        isShooting = true;
    }
}
