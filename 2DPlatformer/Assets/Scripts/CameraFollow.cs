using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //i want the camera to follow the player in 2d space only x axis like mario
    public Transform player; // Reference to the player's transform
    public float smoothSpeed = 1f; // Speed of the camera's movement
    public float maxX = 1f; // Maximum X position for the camera
    private Vector3 targetPosition; // Target position for the camera

    void LateUpdate()
    {
        // Calculate the target position based on the player's position and the offset
        targetPosition = new Vector3(player.position.x, 0, transform.position.z);
        // Clamp the target position to the specified min and max X values
        targetPosition.x = Mathf.Clamp(targetPosition.x, 0, maxX);
        // Smoothly move the camera towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
    }
}