using UnityEngine;
using UnityEngine.UI;

public class ScrollUIBackground : MonoBehaviour
{
    public float speed; // Speed of the background scrolling
    public Vector2 direction; // Direction of the scrolling

    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        image.material.mainTextureOffset += -direction.normalized * speed * Time.deltaTime;
    }
}
