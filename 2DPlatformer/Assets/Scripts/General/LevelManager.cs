using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> levels;
    private int selectedLevel;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SelectLevel(int levelIndex)
    {
        selectedLevel = levelIndex;
        Invoke("LoadLevel", 1.2f); // Delay to ensure the level is selected before loading
    }

    private void LoadLevel()
    {
        if (levels.Count > 0)
        {
            Instantiate(levels[selectedLevel]);
        }
    }
}
