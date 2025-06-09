using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] waypoints;
    private int waypointIndex;
    public float moveSpeed = 3f;
    public bool flipEnabled = true;
    private float distanceThreshold = 0.1f;

    void Update()
    {
        MoveToNextWaypoint();
        Flip();
    }

    void MoveToNextWaypoint()
    {
        if (waypoints.Length > 0)
        {
            if (waypointIndex < waypoints.Length)
            {
                Vector2 targetPosition = waypoints[waypointIndex].position;
                Vector2 currentPosition = transform.position;

                transform.position = Vector2.MoveTowards(currentPosition, targetPosition, moveSpeed * Time.deltaTime);

                if (Vector2.Distance(currentPosition, targetPosition) < distanceThreshold)
                {
                    waypointIndex++;
                    if (waypointIndex >= waypoints.Length)
                    {
                        waypointIndex = 0;
                    }
                }
            }
        }
    }

    void Flip()
    {
        if (flipEnabled)
        {
            if (waypointIndex < waypoints.Length)
            {
                Vector2 targetPosition = waypoints[waypointIndex].position;
                if (targetPosition.x < transform.position.x)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
            }
        }
    }
}
