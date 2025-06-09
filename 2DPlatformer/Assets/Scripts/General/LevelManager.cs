using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> levels;
    private int selectedLevel;
    private float delay = 1.2f;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SelectLevel(int levelIndex)
    {
        selectedLevel = levelIndex;
        Invoke("LoadLevel", delay); 
    }

    private void LoadLevel()
    {
        if (levels.Count > 0)
        {
            Instantiate(levels[selectedLevel]);
        }
    }
}
