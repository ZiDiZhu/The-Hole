using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roommate : MonoBehaviour
{
    public Player player;

    public int foodLevel;
    public int friendship;

    public Sprite normalspr;
    public Sprite hungryspr;
    public Sprite deathspr;
    private SpriteRenderer spriteRenderer;

    public bool isAlive;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        isAlive = true;

    }

    void Update()
    {
        
    }
    
    public void CheckStats()
    {
        if (foodLevel <= 50 && foodLevel >0)
        {
            spriteRenderer.sprite = hungryspr;
        }

        if (foodLevel <= 0)
        {
            StarvedToDeath();
        }
    }

    public void StarvedToDeath()
    {
        isAlive = false;
        //add a death sprite
    }
}
