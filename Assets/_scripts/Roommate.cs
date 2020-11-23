using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Roommate : MonoBehaviour
{

    public GameManager gm;

    public int foodLevel;
    public int friendship;

    public Text friendshipText;
    public Text talkText;


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
        friendshipText.text = "unfriendly";    
    }

    void Update()
    {

    }

    public void CheckStats()
    {
        if (gm.dayPhase ==3 && isAlive)
        {
            spriteRenderer.sprite = sleepingspr;
        }
        if (foodLevel < 50 && foodLevel > 0 && isAlive && gm.dayPhase != 3)
        {
            spriteRenderer.sprite = hungryspr;
        }else if (foodLevel > 50 &&isAlive && gm.dayPhase !=3)
        {
            spriteRenderer.sprite = normalspr;
        }

        if (friendship <= 30)
        {
            friendshipText.text = "unfriendly";
        }
        else if (friendship > 30 && friendship <= 70)
        {
            friendshipText.text = "neutral";
        }
        else if (friendship > 70)
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
            spriteRenderer.sprite = deathspr_rotten;
            isRotten = true;
        }
        else
        {
            spriteRenderer.sprite = deathspr_starved;
            talkText.text = "Eat Corpse";
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
