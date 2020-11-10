using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int floorNum;

    public int monthCount;
    public int dayCount = 0;
    public int playerHealth = 100;
    public int playerFood = 50;

    public Text monthText;
    public Text dayText;
    public Text timeText;
    public Text healthText;
    public Text foodText;
    public Button sleepButton;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + playerHealth;
        foodText.text = "Food: " + playerFood;
        dayText.text = "Day " + dayCount;
    }

    public void Sleep()
    {
        dayCount += 1;
        playerHealth += 20;
        playerFood -= 20;
    }
}
