using UnityEngine;
using TMPro;

public class QuestSystem : MonoBehaviour
{
    public TextMeshProUGUI questText;
    public int questsCompleted = 0;
    public DialogueSystem dialogue;
    public GameObject tomatoes, onions, mushrooms, boxes, enemy, exitRocks, soup;
    public InteractableResource cauldron;
    private bool checkGIConditions = false;
    private bool checkDEConditions = false;
    private bool checkMSConditions = false;
    public AudioSource ambience;
    public AudioSource battleMusic;
    private float fadeSpeed = 1f;
    private float ambienceMaxVolume = 0.1f;
    private float battleMaxVolume = 0.1f;
    public AudioSource zombieSounds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NextQuest();
        ambience.loop = true;
        battleMusic.volume = 0f;
        battleMusic.loop = true;
        battleMusic.Play();
        zombieSounds.volume = 0f;
        zombieSounds.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (checkGIConditions)
        {
            if((tomatoes.activeSelf || onions.activeSelf || mushrooms.activeSelf || boxes.activeSelf) == false)
            {
                questsCompleted++;
                //manually call next quest to trigger defeat enemy quest without having to trigger dialogue
                NextQuest();
                checkGIConditions = false;
            }
        }
        else if (checkDEConditions)
        {
            if (!enemy.activeSelf)
            {
                zombieSounds.volume = 0f;
                ambience.volume = Mathf.MoveTowards(ambience.volume, ambienceMaxVolume, fadeSpeed * Time.deltaTime);
                battleMusic.volume = 0f;
                questsCompleted++;
                NextQuest();
                checkDEConditions = false;
            }
        }
        else if (checkMSConditions)
        {
            if(tomatoes.activeSelf || onions.activeSelf || mushrooms.activeSelf)
            {
                print("You don't have all the ingredients!");
            }
            else if(cauldron.usesRemaining <= 0)
            {
                
                print("Made soup!");
                questsCompleted++;
                string[] newLines =
                {
                    "Indigo: Oh..didn't realize someone was still there.", "Indigo: Sorry about that!! ^^", "You: Here's your soup.", "Indigo: Hmmm......", "Indigo: Fine, good enough.", "Indigo: There, the exit's behind you, be careful next time >:c"
                };
                exitRocks.SetActive(false);
                dialogue.lines = newLines;
                soup.SetActive(true);
                checkMSConditions = false;
            }
            
        }
    }
        
    
    public void NextQuest()
    {
        switch (questsCompleted)
        {
            case 0:
                StartingQuest();
                break;
            case 1:
                DetailsQuest();
                break;
            case 2:
                GatherIngredientsQuest();
                break;
            case 3:
                DefeatEnemyQuest();
                break;
            case 4:
                MakeSoupQuest();
                break;
            case 5:
                EndQuest();
                break;
        }
    }

    public void StartingQuest()
    {
        questText.text = "Quest: \n \nTalk to the ghost.";
        questsCompleted++;
    }

    public void DetailsQuest()
    {
        questText.text = "Quest: \n \nAsk for more details.";
        string[] newLines =
        {
            "You: How can I get out?", "Indigo: Hmm...", "Indigo: If you make me something warm to eat, I'll consider moving those rocks behind you..", "Indigo: The cauldron's north. You'll probably want something to break those boxes."
        };
        dialogue.lines = newLines;
        questsCompleted++;
    }

    public void GatherIngredientsQuest()
    {
        questText.text = "Quest: \n \nGather onions, tomatoes, and mushrooms to make soup. Find something to break the boxes and use the cauldron in the north.";
        string[] waitingLine = {"Indigo: Waiting on that food.. c:"};
        dialogue.lines = waitingLine;

        //checks to see if all conditions have been met
        checkGIConditions = true;
    }
    
    public void DefeatEnemyQuest()
    {
        enemy.SetActive(true);
        zombieSounds.volume = 0.06f;
        battleMusic.volume = Mathf.MoveTowards(battleMusic.volume, battleMaxVolume, fadeSpeed * Time.deltaTime);
        ambience.volume = 0f;
        questText.text = "Quest: \n \nDefeat the enemy.";
        checkDEConditions = true;
    }

    public void MakeSoupQuest()
    {
        questText.text = "Quest: \n \nMake the soup and give it to Indigo.";
        checkMSConditions = true;

    }

    public void EndQuest()
    {
        questText.text = "Quest: \n \nLeave the dungeon.";
        string[] newLines =
        {
            "Indigo: What are you waiting for?", "You: ..."
        };
        dialogue.lines = newLines;
    }

}
