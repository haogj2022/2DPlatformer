using UnityEngine;
using UnityEngine.UI;

public class ScrollUIBackground : MonoBehaviour
{
    public float speed;
    public Vector2 direction;

    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        image.material.mainTextureOffset += -direction.normalized * speed * Time.deltaTime;
    }
}
