using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> levels;
    private int selectedLevel;
    private float delay = 1.1f;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void SelectLevel(int levelIndex)
    {
        selectedLevel = levelIndex;
        Invoke("LoadLevel", delay); 
    }

    private void LoadLevel()
    {
        if (selectedLevel < levels.Count)
        {
            Instantiate(levels[selectedLevel]);
        }
    }

    public void SetStars(int numOfStars)
    {
        PlayerData playerData = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString("PlayerData", "{}"));
        playerData.StarData[selectedLevel] = numOfStars;
        PlayerPrefs.SetString("PlayerData", JsonUtility.ToJson(playerData));
        PlayerPrefs.Save();
    }
}
