using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class LevelStar
{
    public Button level;
    public List<Image> stars;
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
        for (int i = 0; i < LevelStars.Count; i++)
        {
            PlayerPrefs.GetInt("LevelStars_" + i);
            for (int j = 0; j < LevelStars[i].stars.Count; j++)
            {
                if (j < PlayerPrefs.GetInt("LevelStars_" + i))
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
            PlayerPrefs.SetInt("LevelStars_" + i, 0);
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
