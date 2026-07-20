using UnityEngine;
using TMPro;

public class EndGame : MonoBehaviour
{
    public GameObject endPanel;
    public TextMeshProUGUI endText;

    
    public void OnTriggerEnter(Collider other)
    {
        endText.text = "You escaped!";
        endPanel.SetActive(true);
        Time.timeScale = 0;

    }
}
