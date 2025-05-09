using UnityEngine;

public class SpinAnim : MonoBehaviour
{
    public float spinSpeed = 100f; // Speed of the spin animation

    // Update is called once per frame
    void Update()
    {
        // Rotate the object around its Z-axis
        transform.Rotate(0, 0, spinSpeed * Time.deltaTime);
    }
}
