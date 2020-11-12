using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //public Player player;

    public int dayPhase = 1; //1 represents AM, 2 represents lunchtime, 3 represents PM
    public GameObject table;

    public int floorNum;
    public int monthCount;
    public int dayCount = 0;

    public int foodNum;
    public GameObject[] food;

    public Text monthText;
    public Text dayText;
    public Text timeText;
    public Text floorText;
    public Text lowerFloorText;

    void Start()
    {
        UpdateEnvironment();
        //player = GetComponent<Player>();
    }

    
    void Update()
    {

    }

    public void UpdateEnvironment()
    {
        floorText.text = "" + floorNum;

        dayText.text = "Day " + dayCount;
        monthText.text = "Month " + monthCount;

        if (dayPhase == 1) { timeText.text = "A.M."; table.SetActive(false);}
        else if (dayPhase == 2) { timeText.text = "LUNCH"; table.SetActive(true); lowerFloorText.text = ""; GenerateFood(); }
        else if (dayPhase == 3) { timeText.text = "P.M."; table.SetActive(false); lowerFloorText.text = "" + (floorNum + 1); food[foodNum].SetActive(false); }
        else if (dayPhase == 4) { dayCount += 1; dayPhase = 1; UpdateEnvironment(); }

        if (dayCount == 4) { monthCount += 1; dayCount = 1; } //yes,theres 3days in a month for testing
    }

    public void GenerateFood()
    {
        food[foodNum].SetActive(true);
    }

}
