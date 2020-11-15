using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb2d;
    public Vector3 movement;

    public GameManager gm;
    public Roommate roomMate;

    public int foodLevel;
    public int healthLevel;
    public int sanityLevel;

    public Button eatButton;
    public Button sleepButton;
    public Button talkButton;

    public Text foodText;
    public Text healthText;
    public Text sanityText;

    public Text talkText;

    public Sprite playerSpriteNormal;
    public Sprite playerSpriteHungry;
    private SpriteRenderer spriteRenderer;

    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = playerSpriteNormal;
        roomMate.GetComponent<Roommate>().enabled = true;

        sleepButton.interactable = false;
        talkButton.interactable = false;
        eatButton.interactable = false;
    }

    void Update()
    {

    }


    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {

        movement = Vector3.zero;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        rb2d.MovePosition(transform.position + movement * speed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bed")
        {
            Debug.Log("bedtime");
            sleepButton.interactable = true;
        }
        if(collision.gameObject.tag == "Roommate")
        {
            talkButton.interactable = true;
        }
        if(collision.gameObject.tag == "Table")
        {
            eatButton.interactable = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bed")
        {
            Debug.Log("bedtime");
            sleepButton.interactable = false;
        }
        if (collision.gameObject.tag == "Roommate")
        {
            talkButton.interactable = false;
        }
        if(collision.gameObject.tag == "Table")
        {
            eatButton.interactable = false;
        }
    }

    //hard code for now because idk how to access food script through gm i think i did it wrong
    public void Eat()
    {
        if(gm.foodNum == 0)
        {
            foodLevel += 40;
            healthLevel += 20;
            sanityLevel += 20;
            roomMate.foodLevel += 40;
            roomMate.CheckStats();
        }
        else if (gm.foodNum == 1)
        {
            foodLevel += 30;
            healthLevel += 10;
            roomMate.foodLevel += 30;
            roomMate.CheckStats();
        }else if (gm.foodNum == 2)
        {
            foodLevel += 20;
            roomMate.foodLevel += 20;
            roomMate.CheckStats();
        }

        gm.dayPhase += 1;
        gm.UpdateEnvironment();
        roomMate.CheckStats();
        CheckHunger();
    }

    public void Sleep()
    {
        gm.dayPhase += 1;
        gm.UpdateEnvironment();
        healthLevel += 10;
        foodLevel -= 5;
        CheckHunger();
        roomMate.foodLevel -= 5;
        roomMate.CheckStats();

    }

    public void Talk()
    {
        if (roomMate.isAlive)
        {
            foodLevel -= 10;
            sanityLevel += 10;
            gm.dayPhase += 1;
            gm.UpdateEnvironment();
            roomMate.friendship += 10;
            roomMate.foodLevel -= 10;
            roomMate.CheckStats();
            CheckHunger();
        }else if (!roomMate.isAlive)
        {
            if (!roomMate.isRotten)
            {
                roomMate.rotLevel += 10;
                foodLevel += 40;
                healthLevel += 20;
                sanityLevel -= 10;
                gm.dayPhase += 1;
                gm.UpdateEnvironment();
                CheckHunger();
                roomMate.CheckStats();
            }else if (roomMate.isRotten)
            {
                foodLevel += 40;
                healthLevel -= 10;
                sanityLevel -= 20;
                gm.UpdateEnvironment();
                CheckHunger();
            }
        }

    }

    public void CheckHunger()
    {
        if(foodLevel < 50)
        {
            spriteRenderer.sprite = playerSpriteHungry;
        }else if(foodLevel >= 50)
        {
            spriteRenderer.sprite = playerSpriteNormal;
        }

        healthText.text = "Health: " + healthLevel + " / 100";
        foodText.text = "Food: " + foodLevel + " / 100";
        sanityText.text = "Sanity: " + sanityLevel + " / 100";
    }
}
