using UnityEngine;

public class Enemy : InteractableResource
{

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Attack()
    {
        if (swordInHand.activeSelf)
        {
            if(usesRemaining <= 0)
        {
            return;
        }

        usesRemaining--;

        if(usesRemaining <= 0 && destroyWhenEmpty)
        {
            print("Enemy defeated!");
            gameObject.SetActive(false);
        }

        }
        else
        {
            return;
        }
    }
    
}
