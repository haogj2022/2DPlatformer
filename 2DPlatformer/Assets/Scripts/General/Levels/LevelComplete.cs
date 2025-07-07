using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour
{
    public GameObject completionStats;
    public Animator transition;

    public TMP_Text[] starConditionTexts;
    public Image[] starConditionImages;
    public GameObject[] starRatings;

    private PlayerCoin playerCoin;
    private PlayerJump playerJump;
    private Rigidbody2D playerRb;
    private LevelManager levelManager;

    private List<GameObject> coins;
    private List<GameObject> enemies;

    private float currentTime;
    private bool stopTimer;

    private int totalCoins;
    private int totalEnemies;

    private float delay = 1f;

    void Start()
    {
        playerCoin = FindObjectOfType<PlayerCoin>();
        playerJump = FindObjectOfType<PlayerJump>();
        playerRb = playerJump.GetComponent<Rigidbody2D>();
        levelManager = FindObjectOfType<LevelManager>();

        coins = new List<GameObject>(GameObject.FindGameObjectsWithTag("Coin"));
        totalCoins = coins.Count;
        enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("EnemyHead"));
        totalEnemies = enemies.Count;
    }

    private void Update()
    {
        if (!stopTimer)
        {
            currentTime += Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            stopTimer = true;
            playerRb.simulated = false;
            transition.SetTrigger("Play");
            ShowCompletionStats();
        }
    }

    private void ShowCompletionStats()
    {
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        starConditionTexts[0].text = "FINISHED LEVEL (" + time.ToString(@"mm\:ss") + ")";
        starConditionTexts[1].text = "COLLECTED COINS (" + playerCoin.coinCount + "/" + totalCoins + ")";
        starConditionTexts[2].text = "KILLED GHOSTS (" + playerJump.enemiesKilled + "/" + totalEnemies + ")";

        Invoke("ShowStarRatings", delay);
    }

    void ShowStarRatings()
    {
        if (levelManager != null)
        {
            completionStats.SetActive(true);
            starRatings[0].SetActive(true);
            levelManager.SetStars(1);

            if (playerCoin.coinCount >= totalCoins)
            {
                starConditionTexts[1].color = Color.white;
                starConditionImages[1].color = Color.white;
                starRatings[1].SetActive(true);
                levelManager.SetStars(2);
            }

            if (playerJump.enemiesKilled >= totalEnemies)
            {
                starConditionTexts[2].color = Color.white;
                starConditionImages[2].color = Color.white;
                starRatings[2].SetActive(true);
                levelManager.SetStars(3);
            }
        }
    }
}
