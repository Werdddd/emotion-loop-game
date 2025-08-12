using UnityEngine;

public class DisplayDeathMessage : MonoBehaviour
{
    public GameObject deathText;

    void Start()
    {
        deathText.SetActive(false);
    }

    public void ShowDeathMessage()
    {
        deathText.SetActive(true);
    }

    public void HideDeathMessage()
    {
        deathText.SetActive(false);
    }
}
