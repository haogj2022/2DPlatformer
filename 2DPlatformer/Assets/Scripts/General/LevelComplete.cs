using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour
{
    public int totalCoins;
    public TMP_Text completeTime;
    public TMP_Text coinsCollected;
    public GameObject completionStats;
    public GameObject nextButton;
    public GameObject returnButton;
    public Animator transition;
    public TMP_Text[] starConditionTexts;
    public Image[] starConditionImages;
    public GameObject[] starRatings;

    private PlayerCoin PlayerCoin;
    private DeathMenu DeathPanel;

    //start stopwatch
    private float startTime;
    //end stopwatch
    private float endTime;
    //time taken to complete level
    private float timeTaken;

    void Start()
    {
        startTime = Time.time;
        PlayerCoin = FindObjectOfType<PlayerCoin>();
        DeathPanel = FindObjectOfType<DeathMenu>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            transition.SetTrigger("Play");

            endTime = Time.time;
            timeTaken = endTime - startTime;

            int minutes = Mathf.FloorToInt(timeTaken / 60);
            int seconds = Mathf.FloorToInt(timeTaken % 60);

            completeTime.text = string.Format("REACHED THE END ({00:00}:{01:00})", minutes, seconds);
            coinsCollected.text = "COLLECTED ALL COINS (" + PlayerCoin.coinCount + "/" + totalCoins + ")";           

            Invoke("ShowLevelComplete", 1f);
        }
    }

    void ShowLevelComplete()
    {
        completionStats.SetActive(true);
        starRatings[0].SetActive(true);

        if (DeathPanel.deathCount == 0)
        {
            starConditionTexts[0].color = Color.white;
            starConditionImages[0].color = Color.white;
            starRatings[1].SetActive(true);
        }

        if (PlayerCoin.coinCount == totalCoins)
        {
            starConditionTexts[1].color = Color.white;
            starConditionImages[1].color = Color.white;
            starRatings[2].SetActive(true);
        }

        Invoke("ShowOptions", 1f);
    }

    void ShowOptions()
    {
        nextButton.SetActive(true);
        returnButton.SetActive(true);
    }

}
