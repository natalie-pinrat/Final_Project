using UnityEngine;
using TMPro;

public class HealthTextUpdater : MonoBehaviour
{
    public PlayerStatus playerHealth;
    public TextMeshProUGUI healthText;
    void Update()
    {
        healthText.text = "Health: " + playerHealth.health;
    }
}
