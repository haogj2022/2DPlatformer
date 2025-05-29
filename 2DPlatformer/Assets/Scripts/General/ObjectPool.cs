using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int poolSize = 10;
    private GameObject[] pool;
    private int currentIndex = 0;

    private void Awake()
    {
        pool = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            pool[i] = Instantiate(prefab);
            pool[i].SetActive(false);
        }
    }

    public GameObject GetObject()
    {
        GameObject obj = pool[currentIndex];
        currentIndex = (currentIndex + 1) % poolSize;
        obj.SetActive(true);
        return obj;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
    }
}
