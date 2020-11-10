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

    public int foodLevel;
    public int healthLevel;
    public int sanityLevel;

    public Button sleepButton;
    public Button talkButton;

    public Text foodText;
    public Text healthText;
    public Text sanityText;

    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        sleepButton.interactable = false;
    }

    void Update()
    {
        healthText.text = "Health: " + healthLevel + " / 100";
        foodText.text = "Food: " + foodLevel + " / 100";
        sanityText.text = "Sanity: " + sanityLevel + " / 100";
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
    }

    public void Sleep()
    {
        healthLevel += 10;
        foodLevel -= 20;

        gm.dayPhase += 1;
    }
}
