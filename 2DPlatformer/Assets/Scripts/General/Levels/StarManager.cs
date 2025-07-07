using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class LevelStar
{
    public Button level;
    public List<Image> stars;
}

public class PlayerData
{
    public int[] StarData = new int[5];
}

public class StarManager : MonoBehaviour
{
    public List<LevelStar> LevelStars;

    public void Start()
    {
        UpdateStars();
        //ResetStars();
    }

    void UpdateStars()
    {
        PlayerData playerData = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString("PlayerData", "{}"));

        for (int i = 0; i < LevelStars.Count; i++)
        {
            for (int j = 0; j < LevelStars[i].stars.Count; j++)
            {
                if (j < playerData.StarData[i])
                {
                    LevelStars[i].stars[j].color = Color.white;
                    LevelStars[i + 1].level.interactable = true;
                }
            }
        }
    }

    public void ResetStars()
    {
        for (int i = 0; i < LevelStars.Count; i++)
        {
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString("PlayerData", "{}"));
            playerData.StarData = new int[5];
            PlayerPrefs.SetString("PlayerData", JsonUtility.ToJson(playerData));
            PlayerPrefs.Save();

            for (int j = 0; j < LevelStars[i].stars.Count; j++)
            {
                LevelStars[i].stars[j].color = Color.grey;
                LevelStars[i].level.interactable = false;
            }

            if (i == 0)
            {
                LevelStars[i].level.interactable = true;
            }
        }
    }
}
