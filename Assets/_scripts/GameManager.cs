using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //public Player player;

    public int floorNum;
    public int monthCount;
    public int dayCount = 0;

    public Text monthText;
    public Text dayText;
    public Text timeText;
    public Text floorText;
    public Text lowerFloorText;

    void Start()
    {
        //player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        dayText.text = "Day " + dayCount;
    }

}
