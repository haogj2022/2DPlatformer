using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //i want the camera to follow the player in 2d space
    public Transform player; // Reference to the player's transform
    public float smoothSpeed = 1f; // Speed of the camera's movement
    public float maxX; // Maximum X position for the camera
    public float maxY; // Maximum Y position for the camera
    private Vector3 targetPosition; // Target position for the camera

    void LateUpdate()
    {
        // Calculate the target position based on the player's position and the offset
        targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
        // Clamp the target position to the specified values
        targetPosition.x = Mathf.Clamp(targetPosition.x, 0, maxX);
        targetPosition.y = Mathf.Clamp(targetPosition.y, 0, maxY);
        // Smoothly move the camera towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
    }
}