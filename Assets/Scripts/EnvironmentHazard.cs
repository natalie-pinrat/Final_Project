using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnvironmentHazard : MonoBehaviour
{
    
    public PlayerStatus playerHealth;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealth.health -= 10;
        }
    }

    void Update()
    {
        
    }


}
