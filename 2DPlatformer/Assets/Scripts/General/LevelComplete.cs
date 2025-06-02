using TMPro;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public int totalCoins;
    public int totalHiddenAreas;
    public TMP_Text completeTime;
    public TMP_Text coinsCollected;
    public TMP_Text hiddenAreasFound;
    public GameObject levelCompleteMenu;
    public GameObject nextButton;
    public GameObject returnButton;
    public Animator transition;
    
    //start stopwatch
    private float startTime;
    //end stopwatch
    private float endTime;
    //time taken to complete level
    private float timeTaken;

    void Start()
    {
        startTime = Time.time;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // play transition
            transition.SetTrigger("Play");
            endTime = Time.time;
            timeTaken = endTime - startTime;
            // Display level completion stats
            coinsCollected.text = "COINS COLLECTED: " + "/" + totalCoins;

            //time taken in minutes and seconds
            int minutes = Mathf.FloorToInt(timeTaken / 60);
            int seconds = Mathf.FloorToInt(timeTaken % 60);

            completeTime.text = string.Format("COMPLETE TIME: {00:00}:{01:00}", minutes, seconds);
            // Optionally, you can load the next level or show a UI screen here
            Invoke("ShowLevelComplete", 1f);
        }
    }

    void ShowLevelComplete()
    {
        levelCompleteMenu.SetActive(true);
        Invoke("ShowOptions", 2f);
    }

    void ShowOptions()
    {
        nextButton.SetActive(true);
        returnButton.SetActive(true);
    }

}
