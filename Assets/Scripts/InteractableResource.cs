using UnityEngine;

public class InteractableResource : MonoBehaviour
{

    public ItemData item;
    public int amountPerCollect = 1;
    public int usesRemaining = 1;
    public string promptText;
    public string animationTrigger = "GrabFood";
    public DialogueSystem dialogue;
    public GameObject swordInHand;
    public AudioSource swingSound;

    public bool destroyWhenEmpty = true;

    public void Interact(Inventory inventory)
    {
        
        if(usesRemaining <= 0)
        {
            return;
        }

        if(item != null && inventory != null)
        {
            inventory.AddItem(item, amountPerCollect);
        }

        usesRemaining--;

        if(usesRemaining <= 0 && destroyWhenEmpty)
        {
            gameObject.SetActive(false);
        }

        if(item.itemName == "Sword")
        {
            swordInHand.SetActive(true);
        }
    }

    public virtual void Attack()
    {
        swingSound.Play();
        if (swordInHand.activeSelf)
        {
            if(usesRemaining <= 0)
        {
            return;
        }

        usesRemaining--;

        if(usesRemaining <= 0 && destroyWhenEmpty)
        {
            gameObject.SetActive(false);
        }

        }
        else
        {
            return;
        }

    }

    public void Talk()
    {
        dialogue.StartDialogue();
    }
}
