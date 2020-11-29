using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Roommate : MonoBehaviour
{

    public GameManager gm;
    public SceneChanger scene;

    public int foodLevel;
    public int friendship;

    public Text friendshipText;
    public Text talkText;
    public Text foodLevelText;

    public Player player;

    public Sprite normalspr;
    public Sprite sleepingspr;
    public Sprite hungryspr;
    public Sprite deathspr_killed;
    public Sprite deathspr_starved;
    public Sprite deathspr_rotten;

    private SpriteRenderer spriteRenderer;

    public bool isAlive;
    public bool isRotten;
    public int rotLevel;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        isAlive = true;
        isRotten = false;
    }

    void Start()
    {
        CheckStats();
    }

    void Update()
    {

    }

    public void CheckStats()
    {
        if (foodLevel > 150)
        {
            foodLevel = 150;
            foodLevelText.text = "well fed";
        }

        if (gm.dayPhase ==3 && isAlive)
        {
            spriteRenderer.sprite = sleepingspr;
        }
        if (foodLevel < 70 && foodLevel > 0 && isAlive && gm.dayPhase != 3)
        {
            spriteRenderer.sprite = hungryspr;
            foodLevelText.text = "hungry";
        }else if (foodLevel > 70 &&isAlive && gm.dayPhase !=3)
        {
            spriteRenderer.sprite = normalspr;
            foodLevelText.text = "not hungry";
        }

        if (friendship <= 30&& isAlive)
        {
            friendshipText.text = "unfriendly";
            if(this.foodLevel <= 10)
            {
                scene.end2_killed();
            }
        }
        else if (friendship > 30 && friendship <= 70 && isAlive)
        {
            friendshipText.text = "neutral";
        }
        else if (friendship > 70 && isAlive)
        {
            friendshipText.text = "friendly";
        }

        if (foodLevel <= 0 && isAlive)
        {
            StarvedToDeath();
            isAlive = false;
        }
    }

    public void StarvedToDeath()
    {

        if (rotLevel >= 20)
        {
            foodLevelText.text = "rotten";
            friendshipText.text = "dead";
            spriteRenderer.sprite = deathspr_rotten;
            isRotten = true;
        }
        else
        {
            spriteRenderer.sprite = deathspr_starved;
            talkText.text = "Eat Corpse";
            foodLevelText.text = "fresh corpse";
            friendshipText.text = "dead";
        }
    }

    public void Killed()
    {
        isAlive = false;
        
        if (rotLevel >= 20)
        {
            spriteRenderer.sprite = deathspr_rotten;
            isRotten = true;
        }
        else
        {
            spriteRenderer.sprite = deathspr_killed;
            talkText.text = "Eat Corpse";
        }
    }

    public void ChangeRoomMate()
    {

    }
}
