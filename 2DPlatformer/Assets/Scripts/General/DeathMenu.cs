using TMPro;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    [HideInInspector]
    public int deathCount = 0;

    public GameObject deathPanel;
    public TMP_Text deathCountText;

    public void Show()
    {
        Invoke("ShowDeathCount", 2f);
    }

    public void ShowDeathCount()
    {
        deathPanel.SetActive(true);
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
        deathPanel.SetActive(false);
    }
}
