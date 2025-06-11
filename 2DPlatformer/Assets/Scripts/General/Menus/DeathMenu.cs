using TMPro;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    [HideInInspector]
    public int deathCount = 0;

    public GameObject deathPanel;
    public TMP_Text deathCountText;

    private float delay = 2f;

    public void Show()
    {
        Invoke("ShowDeathCount", delay);
    }

    public void ShowDeathCount()
    {
        deathPanel.SetActive(true);
        Invoke("UpdateDeathCount", delay / 2);
    }

    public void UpdateDeathCount()
    {
        deathCount++;
        deathCountText.text = "X" + deathCount;
        Invoke("HideDeathPanel", delay / 2);
    }

    public void HideDeathPanel()
    {
        deathPanel.SetActive(false);
    }
}
