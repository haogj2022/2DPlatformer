using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour
{
    public GameObject completionStats;
    public GameObject nextButton;
    public GameObject returnButton;
    public Animator transition;

    public TMP_Text[] starConditionTexts;
    public Image[] starConditionImages;
    public GameObject[] starRatings;

    private PlayerCoin playerCoin;
    private PlayerJump playerJump;
    private Rigidbody2D playerRb;

    private List<GameObject> coins;
    private List<GameObject> enemies;

    private float startTime;
    private float endTime;
    private float timeTaken;

    private int totalCoins;
    private int totalEnemies;

    void Start()
    {
        startTime = Time.time;

        playerCoin = FindObjectOfType<PlayerCoin>();
        playerJump = FindObjectOfType<PlayerJump>();
        playerRb = playerJump.GetComponent<Rigidbody2D>();

        coins = new List<GameObject>(GameObject.FindGameObjectsWithTag("Coin"));
        totalCoins = coins.Count;

        enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("EnemyHead"));
        totalEnemies = enemies.Count;
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

            starConditionTexts[0].text = string.Format("FINISHED LEVEL ({00:00}:{01:00})", minutes, seconds);
            starConditionTexts[1].text = "COLLECTED COINS (" + playerCoin.coinCount + "/" + totalCoins + ")";
            starConditionTexts[2].text = "KILLED GHOSTS (" + playerJump.enemiesKilled + "/" + totalEnemies + ")";

            Invoke("ShowLevelComplete", 1f);
        }
    }

    void ShowLevelComplete()
    {
        playerRb.simulated = false;
        completionStats.SetActive(true);
        starRatings[0].SetActive(true);

        if (playerCoin.coinCount >= totalCoins)
        {
            starConditionTexts[1].color = Color.white;
            starConditionImages[1].color = Color.white;
            starRatings[1].SetActive(true);
        }

        if (playerJump.enemiesKilled >= totalEnemies)
        {
            starConditionTexts[2].color = Color.white;
            starConditionImages[2].color = Color.white;
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
