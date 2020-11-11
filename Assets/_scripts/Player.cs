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

    public Button sleepButton;
    public Button talkButton;

    public Text foodText;
    public Text healthText;
    public Text sanityText;

    public Sprite playerSpriteNormal;
    public Sprite playerSpriteHungry;
    private SpriteRenderer spriteRenderer;

    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = playerSpriteNormal;

        sleepButton.interactable = false;
        talkButton.interactable = false;
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
    }

    public void Sleep()
    {
        healthLevel += 10;
        foodLevel -= 20;
        
        gm.dayPhase += 1;
        gm.UpdateEnvironment();

        roomMate.foodLevel -= 10;
        CheckHunger();
    }

    public void Talk()
    {
        foodLevel -= 10;
        sanityLevel += 10;
        gm.dayPhase += 1;
        gm.UpdateEnvironment();
        roomMate.friendship += 10;

        CheckHunger();
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
