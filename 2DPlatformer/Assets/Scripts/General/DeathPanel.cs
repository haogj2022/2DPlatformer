using TMPro;
using UnityEngine;

public class DeathPanel : MonoBehaviour
{
    private float deathCount = 0f;
    private TMP_Text deathCountText;

    void Start()
    {
        deathCountText = GetComponentInChildren<TMP_Text>();
    }

    public void Show()
    {
        Invoke("ShowDeathCount", 2f);
    }

    public void ShowDeathCount()
    {
        gameObject.SetActive(true);
        Invoke("UpdateDeathCount", 1f);
    }

    public void UpdateDeathCount()
    {
        deathCount++;
        deathCountText.text = "X" + deathCount;
        Invoke("HideDeathPanel", 1f);
    }

    public void HideDeathPanel()
    {
        gameObject.SetActive(false);
    }
}
