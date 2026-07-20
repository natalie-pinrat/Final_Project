using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] lines;
    public float textSpeed;
    public QuestSystem progressQuests;

    private int index;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogueText.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartDialogue()
    {
        dialogueText.text = string.Empty;
        gameObject.SetActive(true);
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        yield return new WaitForSeconds(0.5f);
        foreach(char c in lines[index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        while(gameObject.activeSelf)
        {
            yield return new WaitForSeconds(5f);
            NextLine();
            yield return new WaitForSeconds(4f);
        }
    }

    void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            progressQuests.NextQuest();
        }
    }
}
