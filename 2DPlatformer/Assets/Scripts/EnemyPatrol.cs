using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] waypoints; // Assign waypoints from the editor
    private int waypointIndex = 0;
    public float moveSpeed = 3f;

    void Update()
    {
        MoveToNextWaypoint();
        Flip();
    }

    void MoveToNextWaypoint()
    {
        if (waypoints.Length > 0) // Check if waypoints are assigned
        {
            if (waypointIndex < waypoints.Length)
            {
                Vector2 targetPosition = waypoints[waypointIndex].position;
                Vector2 currentPosition = transform.position;

                transform.position = Vector2.MoveTowards(currentPosition, targetPosition, moveSpeed * Time.deltaTime);

                if (Vector2.Distance(currentPosition, targetPosition) < 0.1f) // Use a small tolerance for reaching the waypoint
                {
                    waypointIndex++;
                    if (waypointIndex >= waypoints.Length)
                    {
                        waypointIndex = 0; // Reset to start if loop is desired
                    }
                }
            }
        }
    }

    void Flip()
    {
        if (waypointIndex < waypoints.Length)
        {
            Vector2 targetPosition = waypoints[waypointIndex].position;
            if (targetPosition.x < transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1); // Flip left
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1); // Flip right
            }
        }
    }
}
