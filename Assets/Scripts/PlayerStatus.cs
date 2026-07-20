using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerStatus : MonoBehaviour
{
    public int health = 100;
    public GameObject endPanel;

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            endPanel.SetActive(true);
            Time.timeScale = 0f;
        
        }
    }

}
