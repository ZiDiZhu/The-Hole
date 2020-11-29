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
    public ItemEffect item;
    public SceneChanger scene;

    public int foodLevel;
    public int healthLevel;
    public int sanityLevel;

    public GameObject healthdownlogo;

    public Button eatButton;
    public Button sleepButton;
    public Button talkButton;
    public Button useKnifeButton;

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
        useKnifeButton.interactable = false;
        CheckHunger();
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
            if(gm.dayPhase != 3 && roomMate.isAlive)
            {
                talkButton.interactable = true;
            }
            else if(roomMate.isAlive && gm.dayPhase == 3)
            {
                useKnifeButton.interactable = true;
            }else if (!roomMate.isAlive)
            {
                talkButton.interactable = true; // technically a eat corpse button
            }
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
            foodLevel += item.foodVar[0];
            healthLevel += item.healthVar[0];
            sanityLevel += item.sanVar[0];
            roomMate.foodLevel += item.foodVar[0];
            roomMate.CheckStats();
        }
        else if (gm.foodNum == 1)
        {
            foodLevel += item.foodVar[1];
            healthLevel += item.healthVar[1];
            sanityLevel += item.sanVar[1];
            roomMate.foodLevel += item.foodVar[1];
            roomMate.CheckStats();
        }else if (gm.foodNum == 2)
        {
            foodLevel += item.foodVar[2];
            healthLevel += item.healthVar[2];
            sanityLevel += item.sanVar[2];
            roomMate.foodLevel += item.healthVar[2];
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
        healthLevel += item.healthVar[3];
        foodLevel += item.foodVar[3];
        sanityLevel += item.sanVar[3];
        CheckHunger();
        roomMate.foodLevel += item.foodVar[3];
        roomMate.CheckStats();

    }

    public void Talk()
    {
        if (roomMate.isAlive)
        {
            foodLevel += item.foodVar[6];
            healthLevel += item.healthVar[6];
            sanityLevel += item.sanVar[6];
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
                foodLevel += item.foodVar[4];
                healthLevel += item.healthVar[4];
                sanityLevel += item.sanVar[4];
                roomMate.rotLevel += 10;
                gm.dayPhase += 1;
                gm.UpdateEnvironment();
                CheckHunger();
                roomMate.StarvedToDeath();
            }else if (roomMate.isRotten)
            {
                foodLevel += item.foodVar[5];
                healthLevel += item.healthVar[5];
                sanityLevel += item.sanVar[5];
                gm.dayPhase += 1;
                gm.UpdateEnvironment();
                CheckHunger();
                roomMate.StarvedToDeath();
            }
        }

    }

    public void CheckHunger() //Updates stats display
    {
        if(foodLevel < 50)
        {
            spriteRenderer.sprite = playerSpriteHungry;
            if(foodLevel <= 0)
            {
                foodLevel = 0;
                healthLevel -= 20;
                healthdownlogo.SetActive(true);
            }
            else
            {
                healthdownlogo.SetActive(false);
            }

        }
        else if(foodLevel >= 50)
        {
            spriteRenderer.sprite = playerSpriteNormal;
            if(foodLevel > 150)
            {
                foodLevel = 150;
                Debug.Log("FOOD MAXED OUT");
            }
        }

        if(healthLevel > 150)
        {
            healthLevel = 150;
            Debug.Log("health MAXED OUT");
        }
        if(healthLevel <= 0)
        {
            healthLevel = 0;
            if(foodLevel <= 0)
            {
                scene.end1_starved();
            }
        }
        if (sanityLevel > 150)
        {
            sanityLevel = 150;
            Debug.Log("sanity MAXED OUT");
        }

        if (sanityLevel <= 0)
        {
            scene.end3_suicide();
        }

        healthText.text = "Health: " + healthLevel + " / 150";
        foodText.text = "Food: " + foodLevel + " / 150";
        sanityText.text = "Sanity: " + sanityLevel + " / 150";
    }

    public void Death()
    {
        Debug.Log("you're dead");
    }
}
