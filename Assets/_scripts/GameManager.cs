using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //public Player player;

    public int dayPhase = 1; //1 represents AM, 2 represents lunchtime, 3 represents PM
    public GameObject table;

    public GameObject nightFilter; //dark red panel to indicate night time

    public SceneChanger scene;

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

    public Roommate roomMate;
    public GameObject[] roomMatesStuff;

    void Start()
    {
        UpdateEnvironment();
        roomMate.GetComponent<Roommate>().enabled = true;
        //player = GetComponent<Player>();
        nightFilter.SetActive(false);
    }

    
    void Update()
    {

    }

    public void UpdateEnvironment()
    {
        floorText.text = "" + floorNum;
        lowerFloorText.text = "" + (floorNum + 1);

        dayText.text = "Week " + dayCount;
        monthText.text = "Month " + monthCount;

        if (dayPhase == 1) {
            timeText.text = "A.M.";
            table.SetActive(false);
            nightFilter.SetActive(false);
        }
        else if (dayPhase == 2) { timeText.text = "LUNCH"; table.SetActive(true); lowerFloorText.text = ""; GenerateFood(); }
        else if (dayPhase == 3) {
            timeText.text = "P.M.";
            table.SetActive(false);
            lowerFloorText.text = "" + (floorNum + 1);
            food[foodNum].SetActive(false);
            nightFilter.SetActive(true);
        }
        else if (dayPhase == 4) { dayCount += 1; dayPhase = 1; UpdateEnvironment(); }

        if (dayCount == 5)
        {
            monthCount += 1;
            dayCount = 0;
            if (!roomMate.isAlive)
            {
                Destroy(roomMate.gameObject);
                roomMatesStuff[0].SetActive(false);
                roomMatesStuff[1].SetActive(false);
            }

            floorNum = Random.Range(2, 200);
            if (!roomMate.isAlive)
            {
                roomMate.ChangeRoomMate();
            }
            UpdateEnvironment();
        } 

        if(monthCount == 7)
        {
            scene.end4_survive();
        }

    }

    public void GenerateFood()
    {
        //foodNum 0 is best food, 3 is no food at all
        //chances of getting better food is greater when floorNum is lower
        //currently same "sections " of floors gets the same chance of food, this is to be improved using floorNum so the chances downgrades with every floor

        if (floorNum < 20)
        {
            if (Random.Range(0f,10f) > 3f)
            {
                foodNum = 0;
            }
            else
            {
                foodNum = 1;
            }
        }else if (floorNum >= 20 && floorNum < 40)
        {
            if (Random.Range(0f,10f) > 7f)
            {
                foodNum = 0;
            }
            else
            {
                foodNum = 1;
            }
        }else if (floorNum >=40 && floorNum < 60)
        {
            if (Random.Range(0f,10f) > 3f)
            {
                foodNum = 1;
            }
            else
            {
                foodNum = 2;
            }
        }else if (floorNum >= 60 && floorNum < 80)
        {
            if (Random.Range(0f,10f) > 7f)
            {
                foodNum = 1;
            }
            else
            {
                foodNum = 2;
            }
        }else if (floorNum >= 80 && floorNum < 100)
        {
            if(Random.Range(0f,10f) > 3f)
            {
                foodNum = 2;
            }
            else
            {
                foodNum = 3;
            }
        }else if(floorNum >= 100 && floorNum < 160)
        {
            if(Random.Range(0f,10f) > 7f)
            {
                foodNum = 2;
            }
            else
            {
                foodNum = 3;
            }
        }else if (floorNum >= 160)
        {
            foodNum = 3;
        }

        //Spawn the food to the table
        food[foodNum].SetActive(true);
    }

}
