using UnityEngine;
using TMPro;

public class ResourceCounter : MonoBehaviour
{

    public TextMeshProUGUI plumText;
    public TextMeshProUGUI mushroomText;
    public TextMeshProUGUI oreText;

    private int plums;
    private int mushrooms;
    private int ores;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateUI();
    }

    // Update is called once per frame

    private void UpdateUI()
    {
        plumText.text = "Plums: " + plums;
        mushroomText.text = "Mushrooms: " + mushrooms;
        oreText.text = "Ores: " + ores;
    }

    public void AddResource(string resourceName, int amount)
    {
        if(resourceName == "Plum")
        {
            plums += amount;
        }
        else if (resourceName == "Mushroom")
        {
            mushrooms += amount;
        }
        else if (resourceName == "Ore")
        {
            ores += amount;
        }

        UpdateUI();
    }
}
